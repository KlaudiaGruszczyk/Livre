using Application.Common.Interfaces;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookPublisher
{
    public class UpdateBookPublisherCommandHandler : IRequestHandler<UpdateBookPublisherCommand, string>

    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookPublisherCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<string> Handle(UpdateBookPublisherCommand command, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefault();

            if (book == null)
            {
                return default;
            }
            else
            {
                book.Publisher = command.Publisher;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Publisher;
            }
        }
    }
}
