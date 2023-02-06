using MediatR;

namespace Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<GetAllBooksDTO>>
    {

    }
}
