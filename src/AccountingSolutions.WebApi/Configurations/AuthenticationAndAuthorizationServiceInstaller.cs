using AccountingSolutions.Infrastructure.Authentication;
using AccountingSolutions.WebApi.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AccountingSolutions.WebApi.Configurations
{
    public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
        }
    }
}
