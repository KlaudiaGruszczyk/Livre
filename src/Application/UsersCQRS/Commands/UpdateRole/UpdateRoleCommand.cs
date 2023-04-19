using Domain.Enums;
using MediatR;

namespace Application.UsersCQRS.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<int>
    {
        public Guid UserId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
