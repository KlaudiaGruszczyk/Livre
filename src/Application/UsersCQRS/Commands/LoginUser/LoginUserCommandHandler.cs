using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private IApplicationDbContext _dbContext;
        public LoginUserCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);
            if (user == null)
            {
                return false;
            }

            var passwordVerification = BCrypt.Net.BCrypt.Verify(command.Password, user.Password);
            if (!passwordVerification)
            {
                return false;
            }

            return true;
        }
    }
}
