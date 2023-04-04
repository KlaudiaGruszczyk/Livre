using Application.Common.Interfaces;
using Application.UsersCQRS.Commands.ChangeLogin;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        public ChangeEmailCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken cancellationToken)
        {
            var validator = new ChangeEmailCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = _dbContext.Users.Where(a => a.UserId== command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.Email = command.Email;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user.Email;
            }
        }
    }
}
