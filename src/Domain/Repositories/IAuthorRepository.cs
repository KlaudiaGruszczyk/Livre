namespace Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<T>> GetAllAuthors<T>();
        T GetAuthorById<T>(Guid id);
        List<T> GetAuthorByName<T>(string name);
    }
}