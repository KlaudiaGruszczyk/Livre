using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByBook
{
    public class GetLibraryItemsByBookDTO
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
