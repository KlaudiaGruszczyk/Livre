using MediatR;

namespace Application.BooksCQRS.Queries.GetBookByAuthor
{
    public class GetBookByAuthorQuery : IRequest<List<GetBookByAuthorDTO>>
    {
        public Guid AuthorId { get; set; }
    }
}
