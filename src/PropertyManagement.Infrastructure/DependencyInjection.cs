using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using PropertyManagement.Domain.Entities.Users;
using PropertyManagement.Domain.Interfaces.Services.Authentication;
using PropertyManagement.Domain.Services.Authentication;

using PropertyManagement.Application.Interfaces.Meters;
using PropertyManagement.Application.Services;

using PropertyManagement.Infrastructure.Data;
using PropertyManagement.Infrastructure.Repositories;
using PropertyManagement.Infrastructure.Identity;

namespace PropertyManagement.Infrastructure
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc(
					"v1",
					new OpenApiInfo {
						Title = "Property Management Demo API",
						Version = "v1"
					}
				);

				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});

				option.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							}
						},
						new string[]{}
					}
				});
			});


			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
			services.AddDbContext<IdentityDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});


			services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 12;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme =
				options.DefaultChallengeScheme =
				options.DefaultForbidScheme =
				options.DefaultScheme =
				options.DefaultSignInScheme =
				options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = configuration["JWT:Issuer"],
					ValidateAudience = true,
					ValidAudience = configuration["JWT:Audience"],
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
					)
				};
			});


			services.AddScoped<IMeterRepository, MeterRepository>();
			services.AddScoped<IMeterService, MeterService>();

			services.AddScoped<ITokenService, TokenService>();

			return services;
		}
	}
}
