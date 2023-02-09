using MediatR;

namespace Application.BooksCQRS.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksDTO>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
