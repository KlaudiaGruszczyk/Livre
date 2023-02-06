namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author AuthorId { get; set; }
        public Author OtherAuthorId { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }


        public virtual Author? Author { get; set; }
    }
}
