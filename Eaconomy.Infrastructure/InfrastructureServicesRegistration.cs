using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Eaconomy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Eaconomy.Application.Repositories;
using Eaconomy.Infrastructure.Repository;
using Eaconomy.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Eaconomy.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, 
            IConfiguration configuration)

        {
            string mySqlLiteConnectionStr = configuration.GetConnectionString("EaconomyDBConnection");
            services.AddDbContext<EaconomyDBContext>(options =>
             options.UseSqlite(mySqlLiteConnectionStr ??
             throw new InvalidOperationException("Connection string mySqlLiteConnectionStr does not found."))
             );
            services.AddScoped<EaconomyDBReadContext>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
          

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

           

            services
                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            return services;
        }
    }
}
