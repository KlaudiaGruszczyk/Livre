using MediatR;

namespace Application.Book.Commands.CreateBook
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int BookId { get; set; }
    }
}
