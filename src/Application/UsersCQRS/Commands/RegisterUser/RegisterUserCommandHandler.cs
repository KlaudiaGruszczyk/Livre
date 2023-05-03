using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using BC = BCrypt.Net.BCrypt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using FluentValidation;
using Application.UsersCQRS.Commands.RegisterUser;
using System.ComponentModel.DataAnnotations;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;
using Application.Interfaces;

namespace Application.UsersCQRS.Commands.CreateUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;



        public RegisterUserCommandHandler(IApplicationDbContext dbContext, IMediator mediator, IEmailService emailService)
        {
            _dbContext = dbContext;
            _mediator = mediator;
            _emailService = emailService;

        }


        public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserCommandValidator(_dbContext);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync((item) => item.Login == command.Login);

            if (user == null)
            {
                user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Login = command.Login,
                    Password = BC.HashPassword(command.Password),
                    Email = command.Email,
                    Role = UserRole.User,
                    IsActivated = false,
                    AvatarUrl = "www"
                };

                await _dbContext.Users.AddAsync(user);

                var activationToken = Guid.NewGuid();

                var activationLink = new ActivationLink
                {
                    Id = activationToken,
                    UserId = user.UserId,
                    ExpirationDate = DateTime.UtcNow.AddHours(24) 
                };

                await _dbContext.ActivationLinks.AddAsync(activationLink);

                await _dbContext.SaveChangesAsync(cancellationToken);

                var activationUrl = $"http://localhost:4200/activate/{activationToken}"; // front uzupełnić
                await _emailService.SendEmailAsync(user.Email, "Aktywacja konta", $"Kliknij w link, aby aktywować konto: <a href='{activationUrl}'>{activationUrl}</a>");

                return user.UserId;
            }

            throw new ArgumentException("User already exists", command.Login);
        }

    }
}
