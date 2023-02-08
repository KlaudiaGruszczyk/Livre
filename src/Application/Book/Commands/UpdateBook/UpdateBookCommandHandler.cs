using Application.Common.Interfaces;
using MediatR;

namespace Application.Book.Commands.CreateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.Where(a => a.BookId ==command.BookId).FirstOrDefault();
            if (book == null) 
            {
                return default;
            }

            else
            {
                book.BookId = command.BookId;
                book.Title= command.Title;
                book.BookAuthorId = command.BookAuthorId;
                book.AuthorName = command.AuthorName;
                book.Description= command.Description;
                book.PublishedDate = command.PublishedDate;
                book.Category= command.Category;
                book.Publisher = command.Publisher;
                await _dbContext.SaveChangesAsync();
                return (int)book.BookId;


            }
        }
    }
}
