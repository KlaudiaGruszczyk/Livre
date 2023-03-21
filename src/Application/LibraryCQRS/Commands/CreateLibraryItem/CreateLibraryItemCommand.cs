using MediatR;
using Domain.Enums;

namespace Application.LibraryCQRS.Commands.CreateLibraryItem
{
    public class CreateLibraryItemCommand : IRequest<Guid>
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        public Guid UserId { get; set; }
        //public virtual User User { get; set; }

        public Guid BookId { get; set; }
    }
}
