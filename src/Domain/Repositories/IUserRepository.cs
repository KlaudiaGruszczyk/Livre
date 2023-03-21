namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<T>> GetAllUsers<T>();
        T GetUserById<T>(Guid id);
        T GetUserByEmail<T>(string email);
    }
}
