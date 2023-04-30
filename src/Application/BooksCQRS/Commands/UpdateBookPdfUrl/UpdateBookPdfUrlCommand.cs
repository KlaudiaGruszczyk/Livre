using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookPdfUrl
{
    public class UpdateBookPdfUrlCommand : IRequest<string>
    {
        public Guid BookId { get; set; }
        public string PdfUrl { get; set; }
    }
}
