using Application.Common.Interfaces;
using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorName
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorNameCommand, string>

    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateAuthorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateAuthorNameCommand command, CancellationToken cancellationToken)
        {
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
