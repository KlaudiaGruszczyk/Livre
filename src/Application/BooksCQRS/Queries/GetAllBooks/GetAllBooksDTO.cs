using Application.Common.Interfaces;

namespace Application.BooksCQRS.Queries.GetAllBooks
{
    public class GetAllBooksDTO : IBooksList
    {
        public string Title { get; set; }
        public string Author { get; set; }

    }
}
