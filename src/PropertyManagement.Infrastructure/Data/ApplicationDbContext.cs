using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Infrastructure.Identity;

namespace PropertyManagement.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

		public DbSet<Meter> Meters { get; set; }
	}
}
