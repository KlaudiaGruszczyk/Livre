using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookPublishedDate
{
    public class UpdateBookPublishedDateCommand : IRequest<DateTime>
    {
        public Guid BookId { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
