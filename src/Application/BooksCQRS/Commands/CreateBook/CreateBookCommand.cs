using MediatR;

namespace Application.BooksCQRS.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
    }
}
