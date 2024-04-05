using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Application.DTOs.Auth
{
	public class LoginDTO
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
