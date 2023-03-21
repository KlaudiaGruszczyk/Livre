using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetAllLibraryItems
{
    public class GetAllLibraryItemsDTO
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookIdI { get; set; }
    }
}
