using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.ChangeEmail
{
    public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
    {
        public void ChangeEmailValidator(IApplicationDbContext dbContext)
        {

            RuleFor(x => x.Email)
                   .NotEmpty().WithMessage("Email address is required.")
                   .EmailAddress().WithMessage("Invalid email address.")
                   .Custom((value, context) =>
                   {
                       var emailInUse = dbContext.Users.Any(u => u.Email == value);
                       if (emailInUse)
                       {
                           context.AddFailure("Email", "The email is taken");
                       }
                   });
        }
    }
}
