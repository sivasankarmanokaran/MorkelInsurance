using Insurance.Repository.DbContexts;
using Insurance.Repository.DbContexts.Models;
using Insurance.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace Insurance.Repository.Service
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly InsuranceDbContext _dbContext;

        public ClaimRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
            DataSeeder.SeedData(dbContext);
        }

        public async Task<Claim?> GetAsync(int id)
        {
            return await _dbContext.Claims.FindAsync(id);
        }

        public async Task<IEnumerable<Claim>> GetClaimsAsync(int companyId)
        {
            return await _dbContext.Claims.Where(c => c.CompanyId == companyId).ToListAsync();
        }

        public async Task UpdateAsync(Claim model)
        {
            var claim = await _dbContext.Claims.FindAsync(model.Id);

            if (claim != null)
            {
                claim.UCR = model.UCR;
                claim.Assured_Name = model.Assured_Name;
                claim.Incurred_Loss = model.Incurred_Loss;
                claim.LossDate = model.LossDate;
                claim.ClaimDate = model.ClaimDate;
                claim.Closed = model.Closed;
                claim.CompanyId = model.CompanyId;

                _dbContext.Entry(claim).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
            }


        }
    }
}
