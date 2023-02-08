
using MediatR;

namespace Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksDTO>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
