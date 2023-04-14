using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookAuthor
{
    public class UpdateBookAuthorNameCommand : IRequest<string>
    {
        public Guid BookId { get; set; }
        public string Author { get; set; }
    }
}
