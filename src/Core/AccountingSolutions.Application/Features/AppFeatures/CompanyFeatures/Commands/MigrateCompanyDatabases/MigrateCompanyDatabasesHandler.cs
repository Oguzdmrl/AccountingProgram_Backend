using AccountingSolutions.Application.Services.AppServices;
using MediatR;

namespace AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases
{
    public sealed class MigrateCompanyDatabasesHandler : IRequestHandler<MigrateCompanyDatabasesRequest, MigrateCompanyDatabasesResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabasesHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabasesResponse> Handle(MigrateCompanyDatabasesRequest request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}
