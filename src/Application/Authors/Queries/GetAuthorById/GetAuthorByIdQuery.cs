using MediatR;

namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdDTO>
    {
        public int Id { get; set; }
    }
}
