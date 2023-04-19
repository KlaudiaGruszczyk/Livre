using Application.Common.Interfaces;
using MediatR;

namespace Application.UsersCQRS.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRoleCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User is not found");
            }
            else
            {
                user.Role = command.UserRole;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return (int)user.Role;
            }
        }   
    }
}
