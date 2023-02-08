using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Book
    {
        public int? BookId { get; set; }
        public string Title { get; set; }
        public int BookAuthorId { get; set; }
        public string AuthorName { get; set; }
        //[AllowNull]
        //public int OtherAuthorId { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }

        public virtual Author? Author { get; set; }

    }
}
