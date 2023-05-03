using Application.Common.Interfaces;
using Application.UsersCQRS.Commands.ChangeLogin;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserContext _userContext;
        public ChangeEmailCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();

            var validator = new ChangeEmailCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var user = _dbContext.Users.Where(a => a.UserId== command.UserId).FirstOrDefault();

            if (user == null || user.UserId.ToString() != userId)
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
