using Application.Common.Interfaces;

namespace Application.Book.Queries.GetBookById
{
    public class GetBookByIdDTO : IBookDetails
    {

        public int BookId { get; set; }
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
