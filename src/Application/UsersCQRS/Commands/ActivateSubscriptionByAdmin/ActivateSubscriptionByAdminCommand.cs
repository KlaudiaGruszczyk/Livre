using MediatR;

namespace Application.UsersCQRS.Commands.ActivateSubscriptionByAdmin
{
    public class ActivateSubscriptionByAdminCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public bool IsSubscriptionActive { get; set; }
    }
}
