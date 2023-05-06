using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUser
{
    public class GetLibraryItemsByUserDTO
    {
        public Guid LibraryItemId { get; set; }
        public Guid BookId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public string Title { get; set; }
    }
}
