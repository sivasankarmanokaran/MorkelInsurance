using AutoMapper;
using Insurance.Repository.DbContexts.Models;
using Insurance.Repository.Interface;
using Insurance.Service.Dto;
using Insurance.Service.Interface;
using Insurance.Service.Service;
using Moq;

namespace Insurance.Service.Test
{
    public class CompanyServiceTest
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;
        private readonly ICompanyService _companyService;
        private readonly Mock<IMapper> _mapper;
        private readonly Company _company;


        public CompanyServiceTest()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _mapper = new Mock<IMapper>();
            _companyService = new CompanyService(_companyRepositoryMock.Object, _mapper.Object);
            _company = new Company()
            {
                Id = 1,
                Name = "Markel",
                Active = true,
                Address1 = "2nd Floor",
                Address2 = "Verity House",
                Address3 = "6 Canal Wharf",
                Country = "England",
                PostCode = "LS11 5AS",
                InsuranceEndDate = DateTime.Now.AddYears(-1),
            };

        }


        [Fact]
        public async void GetByIdAsync_WhenCalled_Returns_Company_With_HasActiveInsurance_True()
        {
            //Arrange

            var companyDtoModel = new CompanyDto()
            {
                Id = _company.Id,
                Name = _company.Name,
                Active = _company.Active,
                Address1 = _company.Address1,
                Address2 = _company.Address2,
                Address3 = _company.Address3,
                Country = _company.Country,
                PostCode = _company.PostCode,
                InsuranceEndDate = _company.InsuranceEndDate,
                HasActiveInsurance = true
            };

            _mapper.Setup(m => m.Map<CompanyDto>(It.IsAny<Company>())).Returns(companyDtoModel);
            _companyRepositoryMock.Setup(m => m.GetByIdAsync(1)).ReturnsAsync(_company);
            //Act

            var result = await _companyService.GetByIdAsync(1);

            //Assert

            Assert.NotNull(result);
            Assert.True(result.HasActiveInsurance);
        }

        [Fact]
        public async void GetByIdAsync_WhenCalled_Returns_Company_With_HasActiveInsurance_False()
        {
            //Arrange
            var companyDtoModel = new CompanyDto()
            {
                Id = _company.Id,
                Name = _company.Name,
                Active = _company.Active,
                Address1 = _company.Address1,
                Address2 = _company.Address2,
                Address3 = _company.Address3,
                Country = _company.Country,
                PostCode = _company.PostCode,
                InsuranceEndDate = _company.InsuranceEndDate,
                HasActiveInsurance = false
            };


            _mapper.Setup(m => m.Map<CompanyDto>(It.IsAny<Company>())).Returns(companyDtoModel);
            _companyRepositoryMock.Setup(m => m.GetByIdAsync(1)).ReturnsAsync(_company);
            //Act

            var result = await _companyService.GetByIdAsync(1);

            //Assert

            Assert.NotNull(result);
            Assert.False(result.HasActiveInsurance);
        }
    }
}