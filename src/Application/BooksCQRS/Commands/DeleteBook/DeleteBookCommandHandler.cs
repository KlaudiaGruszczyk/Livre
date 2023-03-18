using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BooksCQRS.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefaultAsync();
            if (book == null) return default;
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return (Guid)book.BookId;
        }
    }
}
