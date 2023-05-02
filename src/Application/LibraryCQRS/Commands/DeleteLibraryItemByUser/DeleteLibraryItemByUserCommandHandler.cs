using Application.Common.Interfaces;
using Infrastructure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.LibraryCQRS.Commands.DeleteLibraryItemByUser
{
    public class DeleteLibraryItemByUserCommandHandler : IRequestHandler<DeleteLibraryItemByUserCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserContext _userContext;

        public DeleteLibraryItemByUserCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteLibraryItemByUserCommand command, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();

            var item = await _dbContext.UsersLibraryItems
                .FirstOrDefaultAsync(x => x.UserId == Guid.Parse(userId) && x.LibraryItemId == command.LibraryItemId);

            if (item == null)
            {
                throw new InvalidOperationException($"User with UserId '{userId}' does not have a book with LibraryItemId '{command.LibraryItemId}' assigned.");
            }

            _dbContext.UsersLibraryItems.Remove(item);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
