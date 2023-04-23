using MediatR;

namespace Application.BooksCQRS.Queries.GetAllBooksFullInfo
{
    public class GetAllBooksFullInfoQuery : IRequest<IEnumerable<GetAllBooksFullInfoDTO>>
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }

        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }
}
