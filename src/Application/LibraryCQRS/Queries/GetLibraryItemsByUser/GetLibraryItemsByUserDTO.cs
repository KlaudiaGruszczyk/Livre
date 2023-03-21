using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUser
{
    public class GetLibraryItemsByUserDTO
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
