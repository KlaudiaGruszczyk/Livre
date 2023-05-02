using Application.Common.Interfaces;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.UsersCQRS.Commands.ActivateSubscriptionByAdmin
{
    public class ActivateSubscriptionByAdminCommandHandler : IRequestHandler<ActivateSubscriptionByAdminCommand, Unit>  
    {
        private readonly IApplicationDbContext _dbContext;

        public ActivateSubscriptionByAdminCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<Unit> Handle(ActivateSubscriptionByAdminCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.IsSubscriptionActive = true;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
