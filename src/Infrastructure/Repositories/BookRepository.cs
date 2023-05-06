using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetAllBooksFullInfo;
using Application.BooksCQRS.Queries.GetBookByAuthor;
using Application.BooksCQRS.Queries.GetBookByCategory;
using Application.BooksCQRS.Queries.GetBookById;
using Application.BooksCQRS.Queries.GetBookByKeyWord;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository

    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
           
        public BookRepository(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

       public async Task<List<T>> GetAllBooks<T>()
        {
            var baseQuery = await _dbContext.Books
                .Select(item => new GetAllBooksDTO()
                {
                    BookId = item.BookId,
                    Title = item.Title,
                    Author = item.Author.Name
                }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }

        public async Task<List<T>> GetAllBooksFullInfo<T>()
        {
            var baseQuery = await _dbContext.Books
                .Select(item => new GetAllBooksFullInfoDTO()
                {
                    BookId = item.BookId,
                    Title = item.Title,
                    AuthorName = item.Author.Name,
                    Description = item.Description,
                    PublishedDate = item.PublishedDate,
                    Category = item.Category,
                    Publisher = item.Publisher
                }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }


        public T GetBookById<T>(Guid id)
        {
            var baseQuery = _dbContext.Books
        .Where(item => item.BookId == id)
        .Select(item => new GetBookByIdDTO()
        {
            BookId = item.BookId,
            Title = item.Title,
            AuthorName = item.Author.Name,
            Description = item.Description,
            PublishedDate = item.PublishedDate,
            Category = item.Category,
            Publisher = item.Publisher,
            PdfUrl = item.PdfUrl,
            ImageUrl = item.ImageUrl

        }).OfType<T>()
        .FirstOrDefault();

            return baseQuery;
        }


        public List<T> GetBookByKeyWord<T>(string keyWord)
        {
         var baseQuery = _dbContext.Books
                .Include(author => author.Author)
                .Where(item => item.Title.Contains(keyWord) || item.Author.Name.Contains(keyWord))
                .Select(item => new GetBookByKeyWordDTO()
                {
           BookId = item.BookId,
           Title = item.Title,
           Description = item.Description,
           PublishedDate = item.PublishedDate,
           Category = item.Category,
           Publisher = item.Publisher,
           AuthorName = item.Author.Name
       }).OfType<T>().ToList();

            return baseQuery;
        }

        public List<T> GetBookByAuthor<T>(string name)
        {
            var baseQuery = _dbContext.Books
        .Where(item => item.Author.Name.Contains(name))
        .Select(item => new GetBookByAuthorDTO()
        {
            Title = item.Title,
            AuthorName = item.Author.Name,
            Description = item.Description,
            PublishedDate = item.PublishedDate,
            Category = item.Category,
            Publisher = item.Publisher

        }).OfType<T>().ToList();

            return baseQuery;
        }

        public List<T> GetBookByCategory<T>(string category)
        {
            var baseQuery = _dbContext.Books
            .Where(item => item.Category.Contains(category))
            .Select(item => new GetBookByCategoryDTO()
            {
                Title = item.Title,
                AuthorName = item.Author.Name,
                Description = item.Description,
                PublishedDate = item.PublishedDate,
                Category = item.Category,
                Publisher = item.Publisher

            }).OfType<T>().ToList();

            return baseQuery;
        }
    }
}
