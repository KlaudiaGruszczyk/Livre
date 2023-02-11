using Application.BooksCQRS.Queries.GetAllBooks;
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
                    Title = item.Title,
                    Author = item.AuthorName
                }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }


        public T GetBookById<T>(int id)
        {
            var baseQuery = _dbContext.Books
        .Where(item => item.BookId == id)
        .Select(item => new GetBookByIdDTO()
        {
            Title = item.Title,
            AuthorName = item.AuthorName,
            Description = item.Description,
            PublishedDate = item.PublishedDate,
            Category = item.Category,
            Publisher = item.Publisher

        }).OfType<T>()
        .FirstOrDefault();

            return baseQuery;
        }


        public List<T> GetBookByKeyWord<T>(string keyWord)
        {
            var baseQuery = _dbContext.Books
        .Where(item => item.Title.Contains(keyWord))
        .Select(item => new GetBookByKeyWordDTO()
        {
            Title = item.Title,
            AuthorName = item.AuthorName,
            Description = item.Description,
            PublishedDate = item.PublishedDate,
            Category = item.Category,
            Publisher = item.Publisher

        }).OfType<T>().ToList();

            return baseQuery;
        }

        public List<T> GetBookByAuthor<T>(string name)
        {
            var baseQuery = _dbContext.Books
        .Where(item => item.AuthorName.Contains(name))
        .Select(item => new GetBookByAuthorDTO()
        {
            Title = item.Title,
            AuthorName = item.AuthorName,
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
                AuthorName = item.AuthorName,
                Description = item.Description,
                PublishedDate = item.PublishedDate,
                Category = item.Category,
                Publisher = item.Publisher

            }).OfType<T>().ToList();

            return baseQuery;
        }
    }
}
