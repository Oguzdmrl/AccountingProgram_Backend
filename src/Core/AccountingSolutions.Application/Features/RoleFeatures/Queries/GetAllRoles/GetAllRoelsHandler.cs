using AccountingSolutions.Application.Services.AppServices;
using AccountingSolutions.Domain.AppEntities.Identity;
using MediatR;

namespace AccountingSolutions.Application.Features.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRoelsHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
    {
        private readonly IRoleService _roleService;

        public GetAllRoelsHandler(IRoleService roleService) => _roleService = roleService;

        public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            IList<AppRole> roles = await _roleService.GetAllRolesAsync();
            return new GetAllRolesResponse { Roles = roles };
        }
    }
}