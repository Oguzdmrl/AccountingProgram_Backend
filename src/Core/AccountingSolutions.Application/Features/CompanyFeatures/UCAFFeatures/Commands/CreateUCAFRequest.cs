using MediatR;

namespace AccountingSolutions.Application.Features.CompanyFeatures.UCAFFeatures.Commands
{
    public sealed class CreateUCAFRequest : IRequest<CreateUCAFResponse>
    {
        public string CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}