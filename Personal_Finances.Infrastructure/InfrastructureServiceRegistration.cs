using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Personal_Finances.Application.Contracts.Identity;
using Personal_Finances.Application.Contracts.Persistence;
using Personal_Finances.Application.Models.Identity;
using Personal_Finances.Infrastructure.Models;
using Personal_Finances.Infrastructure.Persistance;
using Personal_Finances.Infrastructure.Repositories;
using Personal_Finances.Infrastructure.Services;
using System.Text;

namespace Personal_Finances.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<FinancesDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>(); ;
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FinancesDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;
        }
    }
}
