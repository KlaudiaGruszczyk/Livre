using FluentValidation;

namespace Application.UsersCQRS.Commands.ChangeEmail
{
    public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
    {
        public void ChangeEmailValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull()
                .WithMessage("UserId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
