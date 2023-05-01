using MediatR;

namespace Application.UsersCQRS.Commands.ActivateUser
{
    public class ActivateUserCommand : IRequest<Unit>
    {
        public Guid Token { get; set; }
    }
}
