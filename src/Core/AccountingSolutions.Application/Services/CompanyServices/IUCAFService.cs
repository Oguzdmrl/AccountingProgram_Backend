using AccountingSolutions.Application.Features.CompanyFeatures.UCAFFeatures.Commands;

namespace AccountingSolutions.Application.Services.CompanyServices
{
    public interface IUCAFService
    {
        Task CreateUcafAsync(CreateUCAFRequest request);
    }
}