using Application.BooksCQRS.Commands.UpdateBookTitle;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookPublishedDate
{
    public class UpdateBookPublisheDateCommandHandler : IRequestHandler<UpdateBookPublishedDateCommand, DateTime>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookPublisheDateCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DateTime> Handle(UpdateBookPublishedDateCommand command, CancellationToken cancellationToken)
        {

            var validator = new UpdateBookPublishedDateCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var book = _dbContext.Books.Where(x => x.BookId== command.BookId).FirstOrDefault();

            if (book == null) 
            {
                return default;
            }

            else
            {
                book.PublishedDate = command.PublishedDate;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.PublishedDate;
            }
        }
    }
}
