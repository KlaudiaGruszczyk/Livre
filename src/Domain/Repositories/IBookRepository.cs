using Application.Book.Queries.GetAllBooks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        //zmienić na GetBooksPage? dodać paginacje itp
        Task<Book?> GetBookById(int id);
        Task<Book?> BookDetails(int id);
        Task<IEnumerable<Book?>> GetBookByTitle(string Name);
        // zmienić na GetBookByKeyWord? 
        Task<Book> Add(Book book);
        Task<Book> Update(Book book);
        Task<Book> Delete(int id);
    }
}
