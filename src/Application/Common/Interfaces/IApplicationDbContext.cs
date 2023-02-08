using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
       DbSet<Domain.Entities.Book> Books { get; }
       DbSet<User> Users { get; }
       DbSet<Author> Authors { get; }
       DbSet<UserLibrary> UsersLibraryItems { get; }
       Task<int> SaveChangesAsync();

    }
}
