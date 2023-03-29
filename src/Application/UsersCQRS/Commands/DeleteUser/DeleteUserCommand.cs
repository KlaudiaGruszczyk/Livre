using MediatR;

namespace Application.UsersCQRS.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
    }
}
