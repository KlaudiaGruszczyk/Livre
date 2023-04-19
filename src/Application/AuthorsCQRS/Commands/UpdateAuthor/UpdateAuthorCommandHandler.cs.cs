using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateAuthorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            
            var author = _dbContext.Authors.Where(a=>a.AuthorId == command.AuthorId).FirstOrDefault();
            if(author == null)
            {
                throw new Exception("Author not found"); 
            }
            
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return author.AuthorId;

        }
    }
}
