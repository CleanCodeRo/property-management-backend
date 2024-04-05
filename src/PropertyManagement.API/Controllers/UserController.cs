using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using PropertyManagement.Domain.Entities.Users;
using PropertyManagement.Domain.Interfaces.Services.Authentication;

using PropertyManagement.Application.DTOs.Auth;

namespace PropertyManagement.API.Controllers
{
    [Route("api/auth")]
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _tokenService;

		public UserController(
			UserManager<AppUser> userManager,
			ITokenService tokenService
		)
		{
			_userManager = userManager;
			_tokenService = tokenService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var appUser = new AppUser
				{
					UserName = registerDTO.Username,
					Email = registerDTO.Email
				};

				var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

				if (createdUser.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

					if (roleResult.Succeeded)
					{
						return Ok(
							new NewUserDTO
							{
								UserName = appUser.UserName,
								Email = appUser.Email,
								Token = _tokenService.CreateToken(appUser)
							}
						);
					}
					else
					{
						return StatusCode(500, roleResult.Errors);
					}
				}
				else
				{
					return StatusCode(500, createdUser.Errors);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
	}
}