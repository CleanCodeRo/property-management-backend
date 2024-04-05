using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities.Users;

namespace PropertyManagement.Infrastructure.Identity
{
	public class IdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public IdentityDbContext(
			DbContextOptions<IdentityDbContext> options)
		: base(options) { }
	}
}
