using Application.Common.Interfaces;
using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateAuthorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = _dbContext.Authors.Where(a => a.AuthorId == command.AuthorId).FirstOrDefault();
            if (author == null)
            {
                return default;
            }

            else
            {
                author.AuthorId = command.AuthorId;
                author.Name = command.Name;
                author.Bio = command.Bio;

                await _dbContext.SaveChangesAsync();
                return (int)author.AuthorId;


            }
        }
    }
}
