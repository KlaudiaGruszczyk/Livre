using Application.BooksCQRS.Commands.UpdateBookTitle;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookDescription
{
    public class UpdateBookDescriptionCommandHandler : IRequestHandler<UpdateBookDescriptionCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookDescriptionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateBookDescriptionCommand command, CancellationToken cancellationToken)
        {

            var validator = new UpdateBookDescriptionCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
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
                book.Description = command.Description;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Description;
            }
        }
    }
}
