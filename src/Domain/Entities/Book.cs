namespace Domain.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }

        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }

        public virtual Author Author { get; set; }

        public ICollection<UserLibrary> UserLibrary { get; set; }

    }
}
