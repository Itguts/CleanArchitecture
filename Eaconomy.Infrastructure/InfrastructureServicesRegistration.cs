using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Eaconomy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Eaconomy.Application.Repositories;
using Eaconomy.Infrastructure.Repository;

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
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
