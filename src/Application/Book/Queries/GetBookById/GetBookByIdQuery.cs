using MediatR;

namespace Application.Book.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetBookByIdDTO>
    {
        public int Id { get; set; }
    }
}
