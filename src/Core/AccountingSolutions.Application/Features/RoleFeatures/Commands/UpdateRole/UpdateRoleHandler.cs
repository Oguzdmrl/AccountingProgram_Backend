using AccountingSolutions.Application.Services.AppServices;
using AccountingSolutions.Domain.AppEntities.Identity;
using MediatR;

namespace AccountingSolutions.Application.Features.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleHandler(IRoleService roleService) => _roleService = roleService;

        public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);
            if (role is null) throw new Exception("Role bulunamadı.");
           
            if (role.Code != request.Code)
            {
                AppRole checkCode = await _roleService.GetByCode(request.Code);
                if (checkCode != null) throw new Exception("Bu kod daha önce kaydedilmiş.");
            }
            
            role.Code = request.Code;
            role.Name = request.Name;
            await _roleService.UpdateAsync(role);
            return new();
        }
    }
}