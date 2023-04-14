using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookTitle
{
    public class UpdateBookTitleCommandHandler : IRequestHandler<UpdateBookTitleCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookTitleCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateBookTitleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookTitleCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if(!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var book = _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefault();

            if (book == null)
            {
                return default;
            }
            else
            {
                book.Title = command.Title;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Title;
            }
        }
    }
}