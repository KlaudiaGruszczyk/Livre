using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public string Bio { get; set; }

        public string PhotoUrl { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
