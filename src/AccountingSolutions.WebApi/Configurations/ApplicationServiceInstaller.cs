using MediatR;

namespace AccountingSolutions.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AccountingSolutions.Application.AssemblyReference).Assembly);

        }
    }
}