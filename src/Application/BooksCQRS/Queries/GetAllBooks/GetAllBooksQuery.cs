using MediatR;

namespace Application.BooksCQRS.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksDTO>>
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
