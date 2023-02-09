using MediatR;

namespace Application.BooksCQRS.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int BookId { get; set; }
    }
}
