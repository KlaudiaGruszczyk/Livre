using Application.Common.Interfaces;
using Application.BooksCQRS.Commands.UpdateBookPdfUrl;
using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookPdfUrl
{
    public class UpdateBookPdfUrlCommandHandler : IRequestHandler<UpdateBookPdfUrlCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookPdfUrlCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<string> Handle(UpdateBookPdfUrlCommand command, CancellationToken cancellationToken)
        {
           
            var book = _dbContext.Books.Where(a=>a.BookId== command.BookId).FirstOrDefault();

            if (book == null)
            {
                return default;
            }

            else
            {
                book.PdfUrl = command.PdfUrl;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return book.PdfUrl;
            }
        }
    }
}
