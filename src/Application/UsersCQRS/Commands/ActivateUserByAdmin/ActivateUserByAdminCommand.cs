using MediatR;

namespace Application.UsersCQRS.Commands.ActivateUserByAdmin
{
    public class ActivateUserByAdminCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public bool IsActivated { get; set; }
    }
}
