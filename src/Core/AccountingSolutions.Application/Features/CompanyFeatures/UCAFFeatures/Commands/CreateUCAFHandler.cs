using AccountingSolutions.Application.Services.CompanyServices;
using MediatR;

namespace AccountingSolutions.Application.Features.CompanyFeatures.UCAFFeatures.Commands
{
    public sealed class CreateUCAFHandler : IRequestHandler<CreateUCAFRequest, CreateUCAFResponse>
    {
        private readonly IUCAFService _ucafService;

        public CreateUCAFHandler(IUCAFService ucafService) => _ucafService = ucafService;

        public async Task<CreateUCAFResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
        {
            await _ucafService.CreateUcafAsync(request);
            return new();
        }
    }
}