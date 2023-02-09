using MediatR;

namespace Application.Authors.Queries.GetAuthorByName
{
    public class GetAuthorByNameQuery : IRequest<List<GetAuthorByNameDTO>>
    {
        public string Name { get; set; }
    }
}
