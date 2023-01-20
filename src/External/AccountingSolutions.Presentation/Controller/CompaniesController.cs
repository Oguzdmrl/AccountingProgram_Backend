using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using AccountingSolutions.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;
using AccountingSolutions.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSolutions.Presentation.Controller
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator) { }
       
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
        {
            CreateCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabases()
        {
            MigrateCompanyDatabasesRequest req = new();
            MigrateCompanyDatabasesResponse res = await _mediator.Send(req);
            return Ok(res);
        }

    }
}
