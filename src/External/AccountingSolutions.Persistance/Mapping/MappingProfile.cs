using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingSolutions.Domain.AppEntities;
using AutoMapper;

namespace AccountingSolutions.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        }
    }
}
