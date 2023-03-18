using MediatR;

namespace Application.BooksCQRS.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Guid>
    {
        public Guid BookId { get; set; }
    }
}
