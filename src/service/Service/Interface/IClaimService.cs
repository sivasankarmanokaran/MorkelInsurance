using Insurance.Service.Dto;
using Insurance.Service.Model;

namespace Insurance.Service.Interface
{
    public interface IClaimService
    {
        Task<IEnumerable<ClaimDto>> GetClaimsAsync(int companyId);
        Task<ClaimDto> GetAsync(int id);
        Task UpdateAsync(ClaimModel model);
    }
}
