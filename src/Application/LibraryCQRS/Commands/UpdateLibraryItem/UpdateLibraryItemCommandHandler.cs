using Application.BooksCQRS.Commands.UpdateBook;
using Application.Common.Interfaces;
using MediatR;

namespace Application.LibraryCQRS.Commands.UpdateLibraryItem
{
    public class UpdateLibraryItemCommandHandler : IRequestHandler<UpdateLibraryItemCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateLibraryItemCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateLibraryItemCommand command, CancellationToken cancellationToken)
        {
            var item = _dbContext.UsersLibraryItems.Where(a => a.LibraryItemId == command.LibraryItemId).FirstOrDefault();
            if (item == null)
            {
                return default;
            }

            else
            {
                item.LibraryItemId = command.LibraryItemId;
                item.ReadingStatus = command.ReadingStatus;
                item.BookId = command.BookId;
                item.UserId = command.UserId;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return (Guid)item.LibraryItemId;


            }
        }
    }
}
