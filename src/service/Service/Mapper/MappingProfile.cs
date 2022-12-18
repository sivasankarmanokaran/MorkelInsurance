using AutoMapper;
using Insurance.Repository.DbContexts.Models;
using Insurance.Service.Dto;
using Insurance.Service.Model;

namespace Insurance.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.HasActiveInsurance, opt => opt.MapFrom(src => src.InsuranceEndDate.Date >= DateTime.Now.Date));

            CreateMap<Claim, ClaimDto>()
               .ForMember(dest => dest.ClaimEndedInDays, opt => opt.MapFrom(src => DateTime.Now.Subtract(src.ClaimDate).TotalDays));

            CreateMap<ClaimModel, Claim>();
        }

    }
}
