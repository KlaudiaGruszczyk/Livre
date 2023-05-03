using Application.Common.Interfaces;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorPhoto
{
    public class UpdateAuthorPhotoCommandHandler : IRequestHandler<UpdateAuthorPhotoCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateAuthorPhotoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateAuthorPhotoCommand command, CancellationToken cancellationToken)
        {
            var author = _dbContext.Authors.Where(a => a.AuthorId == command.AuthorId).FirstOrDefault();

            if (author == null)
            {
                return default;
            }

            else
            { 
                author.PhotoUrl = command.PhotoUrl;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return author.PhotoUrl;
            }
        }
    }
}
