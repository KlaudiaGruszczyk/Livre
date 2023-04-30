using Application.BooksCQRS.Commands.CreateBook;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var book = _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefault();
            var author = await _dbContext.Authors.FindAsync(book.AuthorId);

          

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            else
            {
                book.BookId = command.BookId;
                book.Title = command.Title;
                book.Author.Name = command.AuthorName;
                book.Description = command.Description;
                book.PublishedDate = command.PublishedDate;
                book.Category = command.Category;
                book.Publisher = command.Publisher;
                book.ImageUrl = command.ImageUrl;
                book.PdfUrl = command.PdfUrl;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return (Guid)book.BookId;


            }
        }
    }
}
