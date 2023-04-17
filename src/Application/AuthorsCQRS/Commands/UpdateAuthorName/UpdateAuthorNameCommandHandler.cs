using Application.BooksCQRS.Commands.UpdateBookTitle;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorName
{
    public class UpdateAuthorNameCommandHandler : IRequestHandler<UpdateAuthorNameCommand, string>

    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateAuthorNameCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateAuthorNameCommand command, CancellationToken cancellationToken)
        {

            var validator = new UpdateAuthorNameCommandValidator();

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var author = _dbContext.Authors.Where(a => a.AuthorId == command.AuthorId).FirstOrDefault();

            if (author == null)
            {
                return default;
            }
            else
            {
                author.Name = command.Name;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return author.Name;
            }
        }
    }
}
