using PropertyManagement.Domain.Entities.Users;

namespace PropertyManagement.Domain.Interfaces.Services.Authentication
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}
