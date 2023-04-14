using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookPublisher
{
    public class UpdateBookPublisherCommand : IRequest<string>
    {
        public Guid BookId { get; set; }
        public string Publisher { get; set; }
    }
}
