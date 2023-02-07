using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserLibrary
    {
        [Key]
        public int LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        public int? UserIdItem { get; set; }
        //public virtual User User { get; set; }

        public int? BookIdItem { get; set; }
        //public virtual Book Book { get; set; }

    }
}
