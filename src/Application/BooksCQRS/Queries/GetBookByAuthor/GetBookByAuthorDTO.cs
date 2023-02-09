namespace Application.BooksCQRS.Queries.GetBookByAuthor
{
    public class GetBookByAuthorDTO
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        //[AllowNull]
        //public int OtherAuthorId { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }
}
