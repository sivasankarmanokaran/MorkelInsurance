using AutoMapper;
using Insurance.Repository.DbContexts.Models;
using Insurance.Service.Dto;
using Insurance.Service.Mapper;

namespace Insurance.Service.Test
{
    public class MappingProfileTest
    {
        private readonly Company _company;
        public MappingProfileTest()
        {
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
                InsuranceEndDate = DateTime.Now.AddYears(-1)
            };
        }

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void AutoMapper_CompanyDto_HasActiveInsurance_IsFalse()
        {
            //Arrage
            DateTime insuranceEndDate = DateTime.Now;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var companyDto = mapper.Map<CompanyDto>(_company);

            //Assert
            Assert.NotNull(companyDto);
            Assert.False(companyDto.HasActiveInsurance);
        }

        [Fact]
        public void AutoMapper_CompanyDto_HasActiveInsurance_IsTrue()
        {
            //Arrage
            DateTime insuranceEndDate = DateTime.Now;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();

            _company.InsuranceEndDate = DateTime.Now.AddYears(1);

            //Act
            var companyDto = mapper.Map<CompanyDto>(_company);

            //Assert
            Assert.NotNull(companyDto);
            Assert.True(companyDto.HasActiveInsurance);
        }

        [Fact]
        public void AutoMapper_CompanyDto_ClaimEndedInDays_IsValid()
        {
            //Arrage
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var claimDto = mapper.Map<ClaimDto>(new Claim()
            {
                Id = 100,
                UCR = "10000",
                ClaimDate = DateTime.Now.AddDays(-100),
                LossDate = DateTime.Now.AddDays(-30),
                Assured_Name = "Jack",
                Incurred_Loss = 5000,
                CompanyId = 1,
                Closed = true
            });

            //Assert
            Assert.NotNull(claimDto);
            Assert.Equal(100, claimDto.ClaimEndedInDays);
        }
    }
}
