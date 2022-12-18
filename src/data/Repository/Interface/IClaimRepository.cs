using Insurance.Repository.DbContexts.Models;

namespace Insurance.Repository.Interface
{
    public interface IClaimRepository
    {
        Task<Claim?> GetAsync(int id);
        Task<IEnumerable<Claim>> GetClaimsAsync(int companyId);
        Task UpdateAsync(Claim claim);
    }
}
