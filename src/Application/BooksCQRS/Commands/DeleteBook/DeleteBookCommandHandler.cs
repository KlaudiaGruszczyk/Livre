using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BooksCQRS.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefaultAsync();
            if (book == null) return default;
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return (int)book.BookId;
        }
    }
}
