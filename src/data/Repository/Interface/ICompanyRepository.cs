using Insurance.Repository.DbContexts.Models;

namespace Insurance.Repository.Interface
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(int Id);
    }
}
