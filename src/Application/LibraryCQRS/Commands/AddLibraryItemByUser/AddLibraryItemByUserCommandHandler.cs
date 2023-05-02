using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.LibraryCQRS.Commands.AddLibraryItemByUser
{
    public class AddLibraryItemByUserCommandHandler : IRequestHandler<AddLibraryItemByUserCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserContext _userContext;
        public AddLibraryItemByUserCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }
        public async Task<Guid> Handle(AddLibraryItemByUserCommand command, CancellationToken cancellationToken)
        {

            var userId = _userContext.GetUserId();

            var existingItem = await _dbContext.UsersLibraryItems.FirstOrDefaultAsync(x => x.UserId == Guid.Parse(userId));
            if (existingItem != null)
            {
                throw new InvalidOperationException($"User with UserId '{userId}' already has a book assigned.");
            }

            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == command.BookId);
            if (book == null)
            {
                throw new ArgumentException($"Book with BookId '{command.BookId}' does not exist.");
            }


            var item = new Library();
            item.LibraryItemId = Guid.NewGuid();
            item.ReadingStatus = ReadingStatus.ToRead;
            item.UserId = Guid.Parse(userId);
            item.BookId = command.BookId;

            _dbContext.UsersLibraryItems.Add(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return (Guid)item.LibraryItemId;


        }
    }
}
