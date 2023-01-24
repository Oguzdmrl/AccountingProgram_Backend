using AccountingSolutions.Domain.AppEntities.Identity;
using AccountingSolutions.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace AccountingSolutions.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(SectionName)));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(typeof(AccountingSolutions.Persistance.AssemblyReference).Assembly);

        }
    }
}