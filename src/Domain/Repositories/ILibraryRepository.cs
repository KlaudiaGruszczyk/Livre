using Domain.Enums;

namespace Domain.Repositories
{
    public interface ILibraryRepository
    {
        Task<List<T>> GetAllLibraryItems<T>();
        T GetLibraryItemById<T>(Guid id);
        List<T> GetLibraryItemsByBook<T>(Guid bookId);
        List<T> GetLibraryItemsByStatus<T>(ReadingStatus status);
        List<T> GetLibraryItemsByUser<T>(Guid bookId);
        List<T> GetLibraryItemsByUserAndStatus<T>(Guid userId, ReadingStatus status);


    }
}
