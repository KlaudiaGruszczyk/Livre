using Application.UsersCQRS.Commands.ChangeLogin;
using FluentValidation;

namespace Application.UsersCQRS.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public void ChangePasswordValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull()
                .WithMessage("UserId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage("Password cannot be empty or null.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(25).WithMessage("Password can't be longer than 25 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one non alphanumeric character.");
            RuleFor(x => x.NewPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.NewPassword).Equal(x => x.ConfirmPassword)
          .WithMessage("Nowe hasło i potwierdzone hasło muszą być takie same");

        }
    }
}
