using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUserAndStatus
{
    public class GetLibraryItemsByUserAndStatusDTO
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }

        public string Title { get; set; }

    }
}
