using Domain.Enums;

namespace Domain.Entities
{
    public class UserLibrary
    {
        public int LibraryItemId { get; set; }
        public User UserId { get; set; }
        public Book BookId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

    }
}
