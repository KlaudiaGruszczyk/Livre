using FluentValidation;

namespace Application.UsersCQRS.Commands.ChangeLogin
{
    public class ChangeLoginCommandValidator : AbstractValidator<ChangeLoginCommand>
    {
        public void ChangeLoginValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull()
                .WithMessage("UserId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Login)
                .NotNull().NotEmpty().WithMessage("Login cannot be empty or null.")
                .MaximumLength(25).WithMessage("Login can't be longer than 25 characters.");
            
        }
    }
}
