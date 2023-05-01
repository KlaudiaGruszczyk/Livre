using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;

namespace Application.UsersCQRS.Commands.ActivateUserByAdmin
{
    public class ActivateUserByAdminCommandHandler : IRequestHandler<ActivateUserByAdminCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        public ActivateUserByAdminCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle (ActivateUserByAdminCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.IsActivated = true;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
