using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        Task<List<T>> GetAllBooks<T>();
        //zmienić na GetBooksPage? dodać paginacje itp
        Task<Book?> GetBookById(int id);
        Task<Book?> BookDetails(int id);
        Task<List<Book?>> GetBookByTitle(string Name);
        // zmienić na GetBookByKeyWord? 

    }
}
