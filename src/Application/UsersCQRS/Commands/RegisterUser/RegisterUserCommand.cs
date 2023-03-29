using Domain.Enums;
using MediatR;

namespace Application.UsersCQRS.Commands.CreateUser
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
