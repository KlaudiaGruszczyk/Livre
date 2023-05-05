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
//ConfirmPassword
//:
//"ABC@123abc123"
//NewPassword
//:
//"ABC@123abc123111"
//Password
//:
//"ABC@123abcaaa"