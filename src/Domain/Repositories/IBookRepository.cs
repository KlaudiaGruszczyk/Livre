namespace Domain.Repositories
{
    public interface IBookRepository
    {
        public Task<List<T>> GetAllBooks<T>();
        //zmienić na GetBooksPage? dodać paginacje itp
        public T GetBookById<T>(Guid id);
        List<T> GetBookByKeyWord<T>(string keyWord);
        List<T> GetBookByAuthor<T>(string keyWord);
        List<T> GetBookByCategory<T>(string keyWord);


    }
}
