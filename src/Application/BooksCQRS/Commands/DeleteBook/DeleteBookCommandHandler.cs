using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BooksCQRS.Commands.DeleteBook
{
    public class DeleteBookCommanHandler : IRequestHandler<DeleteBookCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteBookCommanHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefaultAsync();
            if (book == null) 
            {
                throw new Exception("Book not found");
            }

           
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return (Guid)book.BookId;
            
        }
    }
}