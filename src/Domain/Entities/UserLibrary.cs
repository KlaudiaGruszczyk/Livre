using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserLibrary
    {
        public int LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        [ForeignKey("UserForeignKey")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("BookForeignKey")]
        public int? BookId { get; set; }
        public Book Book { get; set; }

    }
}
