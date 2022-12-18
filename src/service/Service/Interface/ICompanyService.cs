using Insurance.Service.Dto;

namespace Insurance.Service.Interface
{
    public interface ICompanyService
    {
        Task<CompanyDto?> GetByIdAsync(int id);
    }
}
