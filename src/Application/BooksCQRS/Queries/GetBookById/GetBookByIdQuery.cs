using MediatR;

namespace Application.BooksCQRS.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetBookByIdDTO>
    {
        public int Id { get; set; }
    }
}
