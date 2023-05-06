using Application.Common.Interfaces;

namespace Application.BooksCQRS.Queries.GetAllBooks
{
    public class GetAllBooksDTO : IBooksList
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Guid AuthorId { get; set; }
    }
}
