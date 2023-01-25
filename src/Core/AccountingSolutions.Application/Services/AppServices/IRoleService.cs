using AccountingSolutions.Application.Features.RoleFeatures.Commands.CreateRole;
using AccountingSolutions.Domain.AppEntities.Identity;

namespace AccountingSolutions.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleRequest request);
        Task UpdateAsync(AppRole appRole);
        Task DeleteAsync(AppRole appRole);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetById(string id);
        Task<AppRole> GetByCode(string code);
    }
}