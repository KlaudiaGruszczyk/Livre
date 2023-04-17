using Application.BooksCQRS.Commands.UpdateBookTitle;
using Application.Common.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.BooksCQRS.Commands.UpdateBookCategory
{
    public class UpdateBookCategoryCommandHandler : IRequestHandler <UpdateBookCategoryCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<string> Handle(UpdateBookCategoryCommand command, CancellationToken cancellationToken)
        {

            var validator = new UpdateBookCategoryCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var book = _dbContext.Books.Where(a=>a.BookId== command.BookId).FirstOrDefault();

            if (book == null) 
            {
                return default;
            }

            else
            {
                book.Category = command.Category;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Category;
            }
        }
    }
}
