using Application.Common.Interfaces;
using Application.UsersCQRS.Commands.CreateUser;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.UsersCQRS.Commands.RegisterUser

{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public  RegisterUserCommandValidator(IApplicationDbContext dbContext)
        {
          
                RuleFor(x => x.Login)
                    .NotEmpty().WithMessage("Login is required.")
                    .MaximumLength(25).WithMessage("Login cannot be longer than 25 characters.");

                RuleFor(x => x.Password)
                    .NotNull().NotEmpty().WithMessage("Password cannot be empty or null.")
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                    .MaximumLength(25).WithMessage("Password can't be longer than 25 characters.")
                    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                    .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                    .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one non alphanumeric character.");


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
