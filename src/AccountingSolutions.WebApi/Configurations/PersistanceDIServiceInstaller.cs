using AccountingSolutions.Application.Services.AppServices;
using AccountingSolutions.Application.Services.CompanyServices;
using AccountingSolutions.Domain;
using AccountingSolutions.Domain.Repositories.UCAFRepositories;
using AccountingSolutions.Persistance;
using AccountingSolutions.Persistance.Repositories.UCAFRepositories;
using AccountingSolutions.Persistance.Services.AppServices;
using AccountingSolutions.Persistance.Services.CompanyServices;

namespace AccountingSolutions.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion
            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion
            #region Repositories
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion
        }
    }
}