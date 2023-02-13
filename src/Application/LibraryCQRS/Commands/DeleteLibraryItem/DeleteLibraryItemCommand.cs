using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Commands.DeleteLibraryItem
{
    public class DeleteLibraryItemCommand : IRequest<int>
    {
        public int LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        public int? UserIdItem { get; set; }
        //public virtual User User { get; set; }

        public int? BookIdItem { get; set; }

    }
}
