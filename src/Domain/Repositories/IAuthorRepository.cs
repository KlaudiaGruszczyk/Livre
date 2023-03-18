namespace Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<T>> GetAllAuthors<T>();
        //zmienić na GetAuthorsPage? dodać paginacje itp
        T GetAuthorById<T>(Guid id);
        List<T> GetAuthorByName<T>(string name);
    }
}