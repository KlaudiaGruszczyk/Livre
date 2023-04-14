using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookTitle
{
    public class UpdateBookTitleCommand : IRequest<string>
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
    }
}
