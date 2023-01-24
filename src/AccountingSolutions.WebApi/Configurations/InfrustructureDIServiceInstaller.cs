using AccountingSolutions.Application.Abstractions;
using AccountingSolutions.Infrastructure.Authentication;

namespace AccountingSolutions.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IJwtProvider, JwtProvider>();
        }
    }
}