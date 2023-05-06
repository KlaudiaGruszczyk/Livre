namespace Domain.Repositories
{
    public interface IBookRepository
    {
        public Task<List<T>> GetAllBooks<T>();
        public Task<List<T>> GetAllBooksFullInfo<T>();
        public T GetBookById<T>(Guid id);
        List<T> GetBookByKeyWord<T>(string keyWord);
        List<T> GetBookByAuthor<T>(Guid id);
        List<T> GetBookByCategory<T>(string keyWord);


    }
}
