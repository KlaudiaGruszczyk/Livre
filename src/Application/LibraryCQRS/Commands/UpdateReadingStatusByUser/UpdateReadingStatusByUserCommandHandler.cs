using Application.Common.Interfaces;
using Infrastructure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.LibraryCQRS.Commands.UpdateReadingStatusByUser
{
    public class UpdateReadingStatusByUserCommandHandler : IRequestHandler<UpdateReadingStatusByUserCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserContext _userContext;

        public UpdateReadingStatusByUserCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task<Guid> Handle(UpdateReadingStatusByUserCommand command, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();
            var parsedUserId = Guid.Parse(userId);

            var item = await _dbContext.UsersLibraryItems
                .Where(item => item.LibraryItemId == command.LibraryItemId)
                .FirstOrDefaultAsync(cancellationToken);

            if (item == null)
            {
                throw new ArgumentException($"Library item with LibraryItemId '{command.LibraryItemId}' does not exist.");
            }

            item.ReadingStatus = command.ReadingStatus;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return (Guid)item.LibraryItemId;
        }
    }
}

