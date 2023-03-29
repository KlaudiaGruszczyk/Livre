using MediatR;

namespace Application.UsersCQRS.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
