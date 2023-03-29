using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Library
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}
