using MediatR;

namespace Application.UsersCQRS.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }

        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
