using Domain.Enums;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUser
{
    public class GetLibraryItemsByUserDTO
    {
        public ReadingStatus ReadingStatus { get; set; }
        public string Title { get; set; }
    }
}
