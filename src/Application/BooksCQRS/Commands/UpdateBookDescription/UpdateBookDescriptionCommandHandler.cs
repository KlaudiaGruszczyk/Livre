using Application.Common.Interfaces;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookDescription
{
    public class UpdateBookDescriptionCommandHandler : IRequestHandler<UpdateBookDescriptionCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookDescriptionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(UpdateBookDescriptionCommand command, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.Where(a => a.BookId == command.BookId).FirstOrDefault();

            if (book == null)
            {
                return default;
            }
            else
            {
                book.Description = command.Description;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Description;
            }
        }
    }
}
