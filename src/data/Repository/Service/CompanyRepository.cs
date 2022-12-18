using Insurance.Repository.DbContexts;
using Insurance.Repository.DbContexts.Models;
using Insurance.Repository.Interface;


namespace Insurance.Repository.Service
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly InsuranceDbContext _dbContext;

        public CompanyRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
            DataSeeder.SeedData(dbContext);
        }
        public async Task<Company?> GetByIdAsync(int Id)
        {
            return await _dbContext.Companies.FindAsync(Id);
        }
    }
}
