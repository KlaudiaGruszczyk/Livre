using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByStatus
{
    public class GetLibraryItemsByStatusDTO

    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
