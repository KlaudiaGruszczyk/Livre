using MediatR;

namespace Application.BooksCQRS.Commands.UpdateBookDescription
{
    public class UpdateBookDescriptionCommand : IRequest<string>
    {
        public Guid BookId { get; set; }
        public string Description { get; set; }
    }
}
