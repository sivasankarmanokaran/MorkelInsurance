using Insurance.Repository.DbContexts;
using Insurance.Repository.DbContexts.Models;
using Insurance.Repository.Interface;
using Insurance.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Repository.Test
{
    public class CompanyRepositoryTest
    {
        private readonly DbContextOptions<InsuranceDbContext> _dbContextOptions;
        private readonly InsuranceDbContext _context;
        private readonly ICompanyRepository _companyRepository;
        public CompanyRepositoryTest() {

            _dbContextOptions = new DbContextOptionsBuilder<InsuranceDbContext>()
            .UseInMemoryDatabase(databaseName: "MyBlogDb")
            .Options;
            _context = new InsuranceDbContext(_dbContextOptions);
            _companyRepository = new CompanyRepository(_context);
        }

        [Fact]
        public async void GetByIdAsync_Returns_ValidCompany()
        {
            //Arrange
            var expectedCompany = new Company
            {
                Id = 101,
                Name = "Royal London Grop",
                Active = true,
                Address1 = "2nd Floor",
                Address2 = "115 Corporation street",
                Address3 = "Manchester",
                Country = "England",
                PostCode = "M4 4AB",
                InsuranceEndDate = DateTime.Now.AddYears(2),
            };

            _context.Companies.Add(expectedCompany);

            _context.SaveChanges();

            //Act

            var result = await _companyRepository.GetByIdAsync(101);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(expectedCompany.Id, result?.Id);
        }

        [Fact]
        public async void GetByIdAsync_Returns_Null()
        {
            //Arrange
            var expectedCompany = new Company
            {
                Id = 102,
                Name = "Royal London Grop",
                Active = true,
                Address1 = "2nd Floor",
                Address2 = "115 Corporation street",
                Address3 = "Manchester",
                Country = "England",
                PostCode = "M4 4AB",
                InsuranceEndDate = DateTime.Now.AddYears(2),
            };

            _context.Companies.Add(expectedCompany);

            _context.SaveChanges();

            //Act

            var result = await _companyRepository.GetByIdAsync(103);

            //Assert

            Assert.Null(result);
        }
    }
}