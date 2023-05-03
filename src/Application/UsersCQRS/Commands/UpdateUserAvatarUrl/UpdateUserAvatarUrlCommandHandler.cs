using Application.Common.Interfaces;
using Infrastructure.Identity;
using MediatR;

namespace Application.UsersCQRS.Commands.UpdateUserAvatarUrl
{
    public class UpdateUserAvatarUrlCommandHandler : IRequestHandler<UpdateUserAvatarUrlCommand, String>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserContext _userContext;

        public UpdateUserAvatarUrlCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task<string> Handle(UpdateUserAvatarUrlCommand command, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();
            var user = _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null || user.UserId.ToString() != userId)
            {
                return default;
            }
            else
            {
                user.AvatarUrl = command.AvatarUrl;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user.AvatarUrl;
            }
        }
    }
}
