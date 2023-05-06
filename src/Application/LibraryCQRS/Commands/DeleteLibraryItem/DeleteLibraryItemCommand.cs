using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Commands.DeleteLibraryItem
{
    public class DeleteLibraryItemCommand : IRequest<Guid>
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }

    }
}
