using AutoMapper;
using Insurance.Repository.DbContexts.Models;
using Insurance.Repository.Interface;
using Insurance.Service.Dto;
using Insurance.Service.Interface;
using Insurance.Service.Model;

namespace Insurance.Service.Service
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _repository;
        private readonly IMapper _mapper;

        public ClaimService(IClaimRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClaimDto> GetAsync(int id)
        {
            var claim = await _repository.GetAsync(id);
            return _mapper.Map<ClaimDto>(claim);
        }

        public async Task<IEnumerable<ClaimDto>> GetClaimsAsync(int companyId)
        {
            var claims = await _repository.GetClaimsAsync(companyId);
            return _mapper.Map<IEnumerable<ClaimDto>>(claims);
        }

        public async Task UpdateAsync(ClaimModel model)
        {
            await _repository.UpdateAsync(_mapper.Map<Claim>(model));
        }
    }
}
