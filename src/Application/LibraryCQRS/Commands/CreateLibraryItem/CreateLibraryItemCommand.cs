using MediatR;
using Domain.Enums;

namespace Application.LibraryCQRS.Commands.CreateLibraryItem
{
    public class CreateLibraryItemCommand : IRequest<Guid>
    {
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
