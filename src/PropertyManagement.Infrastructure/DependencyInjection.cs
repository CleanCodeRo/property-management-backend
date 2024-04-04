using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Infrastructure.Data;
using PropertyManagement.Application.Interfaces;
using PropertyManagement.Application.Services;
using PropertyManagement.Infrastructure.Repositories;

namespace PropertyManagement.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});

			services.AddScoped<IMeterRepository, MeterRepository>();
			services.AddScoped<IMeterService, MeterService>();

			return services;
		}
	}
}
