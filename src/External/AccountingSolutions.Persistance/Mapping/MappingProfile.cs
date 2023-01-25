using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingSolutions.Application.Features.CompanyFeatures.UCAFFeatures.Commands;
using AccountingSolutions.Application.Features.RoleFeatures.Commands.CreateRole;
using AccountingSolutions.Domain.AppEntities;
using AccountingSolutions.Domain.AppEntities.Identity;
using AccountingSolutions.Domain.CompanyEntities;
using AutoMapper;

namespace AccountingSolutions.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<CreateUCAFRequest, UniformChartOfAccount>();
            CreateMap<CreateRoleRequest, AppRole>();
        }
    }
}
