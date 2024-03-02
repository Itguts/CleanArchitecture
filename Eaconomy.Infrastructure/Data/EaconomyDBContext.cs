using Eaconomy.Domain.Entities;
using Eaconomy.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;


namespace Eaconomy.Infrastructure.Data
{
    public class EaconomyDBContext : DbContext
    {
        public EaconomyDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
