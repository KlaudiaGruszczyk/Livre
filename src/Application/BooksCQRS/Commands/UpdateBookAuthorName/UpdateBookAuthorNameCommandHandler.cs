using MediatR;
using FluentValidation;
using Application.Common.Interfaces;

namespace Application.BooksCQRS.Commands.UpdateBookAuthor
{
    public class UpdateBookAuthorNameCommandHandler : IRequestHandler<UpdateBookAuthorNameCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateBookAuthorNameCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Handle(UpdateBookAuthorNameCommand command, CancellationToken cancellationToken)
        {

            var validator = new UpdateBookAuthorNameCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if(!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var book = _dbContext.Books.Where(a=> a.BookId== command.BookId).FirstOrDefault();

            if (book == null)
            {
                return default;
            }

            else
            {
                book.Author.Name = command.Author;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Author.Name;

            }
        }
    }
}
