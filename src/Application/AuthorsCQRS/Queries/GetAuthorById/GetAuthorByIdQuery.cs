using MediatR;

namespace Application.AuthorsCQRS.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdDTO>
    {
        public int Id { get; set; }
    }
}
