using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
                    BookId = new Guid("0c74f13a-b74d-4cf9-b63b-87f9827718d8"),
                    Title = "Romeo i Julia",
                    Description = "Romeo i Julia to dramat Wiliama Szekspira wydany w 1597 roku. Źródeł dzieła można doszukiwać się w dwóch utworach Le tre parti de le Novelle del Bandello oraz Palace of Pleasure.\r\n\r\nMatka Julii Kapulet postanawia wydać córkę za Parysa (jest to krewny księcia Werony). Organizuje ona bal, na którym młodzi mają się zapoznać. Zjawia się tam też potomek zwaśnionego z nimi rodu Monteki, Romeo. Romeo i Julia zakochują się w sobie „od pierwszego wejrzenia”. Wkrótce w tajemnicy biorą ze sobą ślub. Jednak los bywa okrutny….",
                    PublishedDate = new DateTime(1597, 01, 01),
                    Category = "Literatura Klasyczna",
                    Publisher = "Dragon",
                    AuthorId = new Guid("4c857058-91d2-4b7d-90e3-227ceba718a6")
    },
                new Book()
                {
                    BookId = new Guid("f59e02b3-23c3-4d35-9c1a-a2e6a24b9397"),
                    Title = "Gwiezdny Pył",
                    Description = "Młody Tristran Thorn zrobi wszystko, byle tylko zdobyć lodowate serce pięknej Victorii - przyniesie jej nawet gwiazdę, której upadek z nieba oglądali razem pewnej nocy. By jednak to uczynić, musi wyprawić się na niezbadane ziemie po drugiej stronie starożytnego i dobrze pilnowanego muru, od którego bierze nazwę ich maleńka wioska. Za owym murem leży Kraina Czarów, gdzie nic nie jest takie, jakim je sobie wyobraził - nawet upadła gwiazda.",
                    PublishedDate = new DateTime(1999, 01, 01),
                    Category = "Science Fiction",
                    Publisher = "Mag",
                     AuthorId = new Guid("8a2db2b1-c73c-47b5-b70c-5f7b5cb6e930")
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
                    UserId = new Guid("3a1fba2d-e779-4f4d-a9c4-7e060b74d936"),
                    Login = "FirstAdmin",
                    Password = BC.HashPassword("ABC@123abc"),
                    Email = "first.admin@gmail.com",
                    Role = Domain.Enums.UserRole.Admin
                },
                new User()
                {
                    UserId = new Guid("8d6c5b6f-1c2f-45f8-9f97-6e5c4d5f8a7d"),
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
                    AuthorId = new Guid("4c857058-91d2-4b7d-90e3-227ceba718a6"),
                    Name = "William Shakespeare",
                    Bio = "William Szekspir jest uznawany za najwybitniejszego angielskiego poetę i dramaturga. Jest autorem znanych i wybitnych sztuk, takich jak \"Romeo i Julia\", \"Makbet\" oraz \"Hamlet\". Utwory Williama Szekspira cieszą się niesłabnącą mimo upływu czasu popularnością wśród dorosłych oraz młodzieży, która analizuje jego twórczość podczas zajęć lekcyjnych."
                },
                 new Author ()
                 {
                    AuthorId = new Guid("8a2db2b1-c73c-47b5-b70c-5f7b5cb6e930"),
                    Name = "Neil Gaiman",
                    Bio = "Neil Gaiman to brytyjski pisarz, powszechnie uważany za jednego z najwybitniejszych żyjących twórców fantastyki. To właśnie z nim najmocniej kojarzy się termin \"urban fantasy\", chociaż sam pisarz nie ogranicza się jedynie do tego gatunku. Jest autorem licznych powieści grozy, fantasy i science-fiction. Do jego najbardziej znanych dzieł należą: \"Nigdziebądź\", \"Gwiezdny pył\" oraz seria \"Sandman\".\r\n"
                 }
            };
            return authors;
        }

        private IEnumerable<Library> GetUsersLibraryItems()
        {
            var items = new List<Library>()
            {
                new Library()
                {
                    LibraryItemId= new Guid("5c6bd87d-1f76-44c7-ae5c-20cb17f165ed"),
                    ReadingStatus = Domain.Enums.ReadingStatus.ToRead,
                    UserId = new Guid("8d6c5b6f-1c2f-45f8-9f97-6e5c4d5f8a7d"),
                    BookId =new Guid("0c74f13a-b74d-4cf9-b63b-87f9827718d8")
                },
                new Library()
                {
                    LibraryItemId= new Guid("c2a1d3ab-3c43-4133-9a61-76e3a685ce02"),
                    ReadingStatus = Domain.Enums.ReadingStatus.ToRead,
                    UserId = new Guid("3a1fba2d-e779-4f4d-a9c4-7e060b74d936"),
                    BookId =new Guid("0c74f13a-b74d-4cf9-b63b-87f9827718d8")
                }
            };
            return items;
        }
    }
}

