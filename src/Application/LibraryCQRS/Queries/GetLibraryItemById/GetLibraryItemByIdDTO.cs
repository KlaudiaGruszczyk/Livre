using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemById
{
    public class GetLibraryItemByIdDTO
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
