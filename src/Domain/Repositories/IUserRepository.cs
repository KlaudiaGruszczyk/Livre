namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<T>> GetAllUsers<T>();
        T GetUserById<T>(int id);
        T GetUserByEmail<T>(string email);
    }
}
