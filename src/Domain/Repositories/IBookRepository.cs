using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        Task<List<T>> GetAllBooks<T>();
        //zmienić na GetBooksPage? dodać paginacje itp
        T GetBookById<T>(int id);
        Task<Book?> BookDetails(int id);
        List<T> GetBookByKeyWord<T>(string keyWord);
        List<T> GetBookByAuthor<T>(string keyWord);
        List<T> GetBookByCategory<T>(string keyWord);


    }
}
