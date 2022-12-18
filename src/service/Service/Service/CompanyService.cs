using AutoMapper;
using Insurance.Repository.Interface;
using Insurance.Service.Dto;
using Insurance.Service.Interface;

namespace Insurance.Service.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyDto?> GetByIdAsync(int id)
        {
            var company = await _repository.GetByIdAsync(id);
            return _mapper.Map<CompanyDto>(company);
        }
    }
}
