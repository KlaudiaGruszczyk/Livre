using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Commands.UpdateLibraryItem
{
    public class UpdateLibraryItemCommand : IRequest<Guid>
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        public Guid UserId { get; set; }
        //public virtual User User { get; set; }

        public Guid BookId { get; set; }
    }
}
