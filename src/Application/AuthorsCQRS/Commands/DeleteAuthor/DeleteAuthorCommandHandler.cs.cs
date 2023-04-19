using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.AuthorsCQRS.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteAuthorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await _dbContext.Authors.Where(a => a.AuthorId == command.AuthorId).FirstOrDefaultAsync();
            if (author == null)
            { 
                throw new Exception("Author not found");
            }
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return (Guid)author.AuthorId;
        }
    }
}
