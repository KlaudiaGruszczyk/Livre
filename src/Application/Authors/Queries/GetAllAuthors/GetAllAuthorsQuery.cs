
using MediatR;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<GetAllAuthorsDTO>>
    {

    }
}
