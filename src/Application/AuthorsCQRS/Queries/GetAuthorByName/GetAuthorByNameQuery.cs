using MediatR;

namespace Application.AuthorsCQRS.Queries.GetAuthorByName
{
    public class GetAuthorByNameQuery : IRequest<List<GetAuthorByNameDTO>>
    {
        public string Name { get; set; }
    }
}
