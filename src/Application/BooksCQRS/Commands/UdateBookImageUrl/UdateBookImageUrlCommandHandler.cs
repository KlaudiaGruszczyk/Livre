using Application.Common.Interfaces;
using MediatR;

namespace Application.BooksCQRS.Commands.UdateBookImageUrl
{
    public class UpdateBookImageUrlCommandHandler : IRequestHandler<UpdateBookImageUrlCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
         public UpdateBookImageUrlCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Handle(UpdateBookImageUrlCommand command, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefault();

            if (book == null)
            {
                return default;
            }

            else
            {
                book.ImageUrl = command.ImageUrl;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.ImageUrl;
            }
        }
    }
}