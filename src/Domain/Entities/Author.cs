using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Author
    {
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        
        public virtual List<Book> Books { get; set; }
    }
}
