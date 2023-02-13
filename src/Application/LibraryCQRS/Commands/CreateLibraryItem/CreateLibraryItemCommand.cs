using MediatR;
using Domain.Enums;

namespace Application.LibraryCQRS.Commands.CreateLibraryItem
{
    public class CreateLibraryItemCommand : IRequest<int>
    {
        public int LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        public int? UserIdItem { get; set; }
        //public virtual User User { get; set; }

        public int? BookIdItem { get; set; }
    }
}
