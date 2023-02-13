using Application.BooksCQRS.Commands.CreateBook;
using Application.Common.Interfaces;
using MediatR;

namespace Application.LibraryCQRS.Commands.CreateLibraryItem
{
    public class CreateLibraryItemCommandHandler : IRequestHandler<CreateLibraryItemCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateLibraryItemCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateLibraryItemCommand command, CancellationToken cancellationToken)
        {
            var item = new Domain.Entities.UserLibrary();

            item.LibraryItemId = command.LibraryItemId;

            item.ReadingStatus = command.ReadingStatus;
            item.UserIdItem = command.UserIdItem;
            item.BookIdItem = command.BookIdItem;
            _dbContext.UsersLibraryItems.Add(item);
            await _dbContext.SaveChangesAsync();
            return (int)item.LibraryItemId;


        }
    }
}
