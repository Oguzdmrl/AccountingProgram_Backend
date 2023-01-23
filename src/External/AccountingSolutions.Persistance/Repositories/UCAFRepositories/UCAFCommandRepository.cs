using AccountingSolutions.Domain.CompanyEntities;
using AccountingSolutions.Domain.Repositories.UCAFRepositories;

namespace AccountingSolutions.Persistance.Repositories.UCAFRepositories
{
    public sealed class UCAFCommandRepository : CommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}