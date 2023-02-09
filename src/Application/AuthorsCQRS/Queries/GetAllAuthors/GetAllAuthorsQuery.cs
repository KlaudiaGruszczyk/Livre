using MediatR;

namespace Application.AuthorsCQRS.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<GetAllAuthorsDTO>>
    {

    }
}
