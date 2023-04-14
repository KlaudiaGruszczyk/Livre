using Application.Common.Interfaces;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookCategory
{
    public class UpdateBookPublisherCommandHandler : IRequestHandler <UpdateBookCategoryCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookPublisherCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<string> Handle(UpdateBookCategoryCommand command, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.Where(a=>a.BookId== command.BookId).FirstOrDefault();

            if (book == null) 
            {
                return default;
            }

            else
            {
                book.Category = command.Category;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.Category;
            }
        }
    }
}
