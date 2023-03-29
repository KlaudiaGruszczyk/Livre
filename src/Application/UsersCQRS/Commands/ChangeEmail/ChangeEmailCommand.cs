using MediatR;

namespace Application.UsersCQRS.Commands.ChangeEmail
{
    public class ChangeEmailCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
