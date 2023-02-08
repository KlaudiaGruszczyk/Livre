using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using BC = BCrypt.Net.BCrypt;


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

                if (!_dbContext.Authors.Any())
                {
                    var authors = GetAuthors();
                    _dbContext.Authors.AddRange(authors);
                    _dbContext.SaveChanges();
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
                {         
                    BookId = 1,
                    Title = "Romeo i Julia",
                    BookAuthorId = 1,
                    AuthorName = "William Shakespeare",
                    Description = "Romeo i Julia to dramat Wiliama Szekspira wydany w 1597 roku. Źródeł dzieła można doszukiwać się w dwóch utworach Le tre parti de le Novelle del Bandello oraz Palace of Pleasure.\r\n\r\nMatka Julii Kapulet postanawia wydać córkę za Parysa (jest to krewny księcia Werony). Organizuje ona bal, na którym młodzi mają się zapoznać. Zjawia się tam też potomek zwaśnionego z nimi rodu Monteki, Romeo. Romeo i Julia zakochują się w sobie „od pierwszego wejrzenia”. Wkrótce w tajemnicy biorą ze sobą ślub. Jednak los bywa okrutny….",
                    PublishedDate = new DateTime(1597, 01, 01),
                    Category = "Literatura Klasyczna",
                    Publisher = "Dragon"
    },
                new Book()
                {
                    BookId = 2,
                    Title = "Gwiezdny Pył",
                    BookAuthorId = 2,
                    AuthorName = "NeilGaiman",
                    Description = "Młody Tristran Thorn zrobi wszystko, byle tylko zdobyć lodowate serce pięknej Victorii - przyniesie jej nawet gwiazdę, której upadek z nieba oglądali razem pewnej nocy. By jednak to uczynić, musi wyprawić się na niezbadane ziemie po drugiej stronie starożytnego i dobrze pilnowanego muru, od którego bierze nazwę ich maleńka wioska. Za owym murem leży Kraina Czarów, gdzie nic nie jest takie, jakim je sobie wyobraził - nawet upadła gwiazda.",
                    PublishedDate = new DateTime(1999, 01, 01),
                    Category = "Science Fiction",
                    Publisher = "Mag"
                }
            };
            return books;
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    Login = "FirstAdmin",
                    Password = BC.HashPassword("ABC@123abc"),
                    Email = "first.admin@gmail.com",
                    Role = Domain.Enums.UserRole.Admin
                },
                new User()
                {
                    UserId = 2,
                    Login = "FirstUser",
                    Password = BC.HashPassword("ABC@123abc"),
                    Email = "first.usern@gmail.com",
                    Role = Domain.Enums.UserRole.User
                }
            };
            return users;
        }

        private IEnumerable<Author> GetAuthors()
        {
            var authors = new List<Author>()
            {
                new Author ()
                {
                    AuthorId = 1,
                    Name = "William Shakespeare",
                    Bio = "William Szekspir jest uznawany za najwybitniejszego angielskiego poetę i dramaturga. Jest autorem znanych i wybitnych sztuk, takich jak \"Romeo i Julia\", \"Makbet\" oraz \"Hamlet\". Utwory Williama Szekspira cieszą się niesłabnącą mimo upływu czasu popularnością wśród dorosłych oraz młodzieży, która analizuje jego twórczość podczas zajęć lekcyjnych."
                },
                 new Author ()
                 {
                    AuthorId = 2,
                    Name = "Neil Gaiman",
                    Bio = "Neil Gaiman to brytyjski pisarz, powszechnie uważany za jednego z najwybitniejszych żyjących twórców fantastyki. To właśnie z nim najmocniej kojarzy się termin \"urban fantasy\", chociaż sam pisarz nie ogranicza się jedynie do tego gatunku. Jest autorem licznych powieści grozy, fantasy i science-fiction. Do jego najbardziej znanych dzieł należą: \"Nigdziebądź\", \"Gwiezdny pył\" oraz seria \"Sandman\".\r\n"
                 }
            };
            return authors;
        }

        private IEnumerable<UserLibrary> GetUsersLibraryItems()
        {
            var items = new List<UserLibrary>() 
            { 
                new UserLibrary()
                {
                    LibraryItemId= 1,
                    ReadingStatus = Domain.Enums.ReadingStatus.ToRead,
                    UserIdItem = 1,
                    BookIdItem =2
                }, 
                new UserLibrary() 
                {
                    LibraryItemId= 2,
                    ReadingStatus = Domain.Enums.ReadingStatus.ToRead,
                    UserIdItem = 1,
                    BookIdItem =1
                } 
            };
            return items;
        }
    }
}
 
