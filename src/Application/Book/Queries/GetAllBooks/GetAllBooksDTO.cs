using Application.Common.Interfaces;

namespace Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksDTO :IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }

    }
}
