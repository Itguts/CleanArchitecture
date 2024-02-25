using Eaconomy.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Eaconomy.Infrastructure.Data
{
    public class EaconomyDBContext : DbContext
    {
        public EaconomyDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
