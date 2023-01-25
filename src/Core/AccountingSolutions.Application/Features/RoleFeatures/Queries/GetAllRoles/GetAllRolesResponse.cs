using AccountingSolutions.Domain.AppEntities.Identity;

namespace AccountingSolutions.Application.Features.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRolesResponse
    {
        public IList<AppRole> Roles { get; set; }
    }
}