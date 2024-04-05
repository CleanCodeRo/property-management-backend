using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Domain.Entities.Users;

namespace PropertyManagement.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

		public DbSet<Meter> Meters { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
