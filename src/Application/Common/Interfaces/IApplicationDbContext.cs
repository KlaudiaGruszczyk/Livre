using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Book> Books { get; }
        DbSet<User> Users { get; }
        DbSet<Author> Authors { get; }
        DbSet<Library> UsersLibraryItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }



    }
}
