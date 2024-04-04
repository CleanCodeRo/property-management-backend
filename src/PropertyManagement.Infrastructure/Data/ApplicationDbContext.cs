using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

		public DbSet<Meter> Meters { get; set; }
	}
}
