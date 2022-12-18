using Insurance.Api.Company.Controllers;
using Insurance.Service.Dto;
using Insurance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Insurance.Api.Company.Test
{
    public class CompanyControllerTest
    {
        private readonly Mock<ICompanyService> _companyServiceMock;
        private readonly CompanyController _companyController;

        public CompanyControllerTest()
        {
            _companyServiceMock = new Mock<ICompanyService>();
            _companyController = new CompanyController(_companyServiceMock.Object);
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsOKResult()
        {
            //Arrange 
            int expectedId = 1;
            bool expectedHasActiveInsurance = true;

            var mockCompany = new Service.Dto.CompanyDto
            {
                Id = 1,
                Name = "Markel",
                Active = true,
                Address1 = "2nd Floor",
                Address2 = "Verity House",
                Address3 = "6 Canal Wharf",
                Country = "England",
                PostCode = "LS11 5AS",
                HasActiveInsurance = true,
                InsuranceEndDate = DateTime.UtcNow,
            };

            _companyServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockCompany);

            //Act
            var okResult = (await _companyController.Get(1)) as OkObjectResult;


            //Assert
            Assert.IsType<OkObjectResult>(okResult);
            var company = Assert.IsType<CompanyDto>(okResult.Value);
            Assert.Equal(expectedId, company.Id);
            Assert.Equal(expectedHasActiveInsurance, company.HasActiveInsurance);
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsNotFoundResult()
        {
            //Arrange 

            _companyServiceMock.Setup(m => m.GetByIdAsync(1)).ReturnsAsync(null as CompanyDto);

            //Act
            var notFoundResult = await _companyController.Get(1);


            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}