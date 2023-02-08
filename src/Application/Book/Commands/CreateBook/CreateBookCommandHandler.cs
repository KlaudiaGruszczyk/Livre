using Application.Common.Interfaces;
using MediatR;

namespace Application.Book.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle (CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Domain.Entities.Book();

            book.BookId = command.BookId;
           
            book.Title = command.Title;
            book.BookAuthorId = command.BookAuthorId;
            book.AuthorName = command.AuthorName;
            book.Description = command.Description;
            book.PublishedDate = command.PublishedDate;
            book.Category = command.Category;
            book.Publisher = command.Publisher;

            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
                return (int)book.BookId;


            }
        }
    }

