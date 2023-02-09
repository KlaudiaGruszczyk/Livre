using Application.Book.Queries.GetBookByKeyWord;
using MediatR;

namespace Application.Book.Queries.GetBookByAuthor
{
    public class GetBookByAuthorQuery : IRequest<List<GetBookByAuthorDTO>>
    {
        public string Name { get; set; }
    }
}
