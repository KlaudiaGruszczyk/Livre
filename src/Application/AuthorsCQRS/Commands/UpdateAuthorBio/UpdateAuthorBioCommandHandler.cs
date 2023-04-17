using Application.BooksCQRS.Commands.UpdateBookTitle;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorBio
{
    public class UpdateAuthorBioCommandHandler : IRequestHandler<UpdateAuthorBioCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateAuthorBioCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateAuthorBioCommand command, CancellationToken cancellationToken)
        {


            var validator = new UpdateAuthorBioCommandValidator();

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
                author.Bio = command.Bio;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return author.Bio;
            }
        }
    }
}
