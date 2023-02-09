using Domain.Enums;

namespace Domain.Repositories
{
    public interface ILibraryRepository
    {
        Task<List<T>> GetAllLibraryItems<T>();
        T GetLibraryItemById<T>(int id);
        List<T> GetLibraryItemsByBook<T>(int bookId);
        List<T> GetLibraryItemsByStatus<T>(ReadingStatus status);
        List<T> GetLibraryItemsByUser<T>(int bookId);


    }
}
