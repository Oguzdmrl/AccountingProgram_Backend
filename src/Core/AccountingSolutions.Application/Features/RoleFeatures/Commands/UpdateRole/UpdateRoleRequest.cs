using MediatR;

namespace AccountingSolutions.Application.Features.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleRequest : IRequest<UpdateRoleResponse>
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}