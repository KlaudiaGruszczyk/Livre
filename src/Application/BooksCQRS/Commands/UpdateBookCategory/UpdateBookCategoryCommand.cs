using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookCategory
{
    public class UpdateBookCategoryCommand : IRequest<string>
    {
        public Guid BookId { get; set; }
        public string Category { get; set; }
    }
}
