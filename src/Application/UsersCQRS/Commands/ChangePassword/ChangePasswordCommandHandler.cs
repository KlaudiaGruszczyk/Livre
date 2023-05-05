using Application.Common.Interfaces;
using Application.UsersCQRS.Commands.ChangePassword;
using Infrastructure.Identity;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.UsersCQRS.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserContext _userContext;

        public ChangePasswordCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task<bool> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();

            var validator = new ChangePasswordCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var user = await _dbContext.Users.FindAsync(command.UserId);
            if (user == null || user.UserId.ToString() != userId)
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