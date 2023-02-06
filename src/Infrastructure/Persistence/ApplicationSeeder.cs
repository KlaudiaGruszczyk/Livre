using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }


                if (!_dbContext.Books.Any())
                {
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Authors.Any())
                {
                    var authors = GetAuthors();
                    _dbContext.Authors.AddRange(authors);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.UsersLibraryItems.Any())
                {
                    var items = GetUsersLibraryItems();
                    _dbContext.UsersLibraryItems.AddRange(items);
                    _dbContext.SaveChanges();
                }
            }
        }



        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                { },
                new Book()
                { }
            };
            return books;
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                { },
                new User()
                { }
            };
            return users;
        }

        private IEnumerable<Author> GetAuthors()
        {
            var authors = new List<Author>()
            {
                new Author ()
                { },
                 new Author ()
                { }
            };
            return authors;
        }

        private IEnumerable<UserLibrary> GetUsersLibraryItems()
        {
            var items = new List<UserLibrary>() 
            { 
                new UserLibrary()
                { }, 
                new UserLibrary() 
                { } 
            };
            return items;
        }
    }
}
 
