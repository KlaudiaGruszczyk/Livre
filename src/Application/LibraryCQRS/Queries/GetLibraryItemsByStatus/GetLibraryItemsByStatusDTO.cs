using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByStatus
{
    public class GetLibraryItemsByStatusDTO

    {
        public int LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public int? UserIdItem { get; set; }
        public int? BookIdItem { get; set; }
    }
}
