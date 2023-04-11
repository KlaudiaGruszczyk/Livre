using Application.Common.Interfaces;
using Application.UsersCQRS.Commands.ChangeLogin;
using FluentValidation;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.UsersCQRS.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        public ChangePasswordCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var validator = new ChangePasswordCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var user = await _dbContext.Users.FindAsync(command.UserId);
            if (user == null)
            {
                return false;
            }

            var isOldPasswordCorrect = BCrypt.Net.BCrypt.Verify(command.Password, user.Password);

            if (!isOldPasswordCorrect)
            {
                return false;
            }

            var newPassword = BCrypt.Net.BCrypt.HashPassword(command.NewPassword);
            user.Password = newPassword;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
