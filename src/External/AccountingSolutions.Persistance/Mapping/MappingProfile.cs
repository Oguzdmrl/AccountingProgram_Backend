using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingSolutions.Application.Features.CompanyFeatures.UCAFFeatures.Commands;
using AccountingSolutions.Domain.AppEntities;
using AccountingSolutions.Domain.CompanyEntities;
using AutoMapper;

namespace AccountingSolutions.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
            CreateMap<CreateUCAFRequest, UniformChartOfAccount>().ReverseMap();
        }
    }
}
