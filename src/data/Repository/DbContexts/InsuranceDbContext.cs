using Insurance.Repository.DbContexts.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Repository.DbContexts
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; } = null!;

        public DbSet<Claim> Claims { get; set; } = null!;
    }
}
