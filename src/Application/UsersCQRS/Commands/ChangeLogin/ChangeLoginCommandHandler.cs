using Application.Common.Interfaces;
using MediatR;

namespace Application.UsersCQRS.Commands.ChangeLogin
{
    public class ChangeLoginCommandHandler : IRequestHandler<ChangeLoginCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public ChangeLoginCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(ChangeLoginCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.Login = command.Login;
                await _dbContext.SaveChangesAsync();
                return user.Login;
            }
        }
    }
}
