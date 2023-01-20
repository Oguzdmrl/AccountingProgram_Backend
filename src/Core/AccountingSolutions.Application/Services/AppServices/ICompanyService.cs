using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingSolutions.Domain.AppEntities;

namespace AccountingSolutions.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);
        Task MigrateCompanyDatabases();
        Task<Company?> GetCompanyByName(string name);
    }
}
