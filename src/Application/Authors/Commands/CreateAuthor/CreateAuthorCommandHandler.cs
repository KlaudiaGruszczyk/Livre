using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {

        private readonly IApplicationDbContext _dbContext;
        public CreateAuthorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = new Domain.Entities.Author();

            author.AuthorId = command.AuthorId;
            author.Name = command.Name;
            author.Bio = command.Bio;

            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return (int)author.AuthorId;


        }
    }
}

