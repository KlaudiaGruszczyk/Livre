using Application.BooksCQRS.Commands.CreateBook;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.LibraryCQRS.Commands.CreateLibraryItem
{
    public class CreateLibraryItemCommandHandler : IRequestHandler<CreateLibraryItemCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateLibraryItemCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateLibraryItemCommand command, CancellationToken cancellationToken)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == command.UserId);
            if (user == null)
            {
                throw new ArgumentException($"User with UserId '{command.UserId}' does not exist.");
            }

            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == command.BookId);
            if (book == null)
            {
                throw new ArgumentException($"Book with BookId '{command.BookId}' does not exist.");
            }

            var item = new UserLibrary();

            item.LibraryItemId = command.LibraryItemId;

            item.ReadingStatus = command.ReadingStatus;
            item.UserId = command.UserId;
            item.UserId = command.UserId;

            _dbContext.UsersLibraryItems.Add(item);
            await _dbContext.SaveChangesAsync();
            return (Guid)item.LibraryItemId;


        }
    }
}
