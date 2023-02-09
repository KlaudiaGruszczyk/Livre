using Application.Book.Queries.GetAllBooks;
using Application.Book.Queries.GetBookByAuthor;
using Application.Book.Queries.GetBookByCategory;
using Application.Book.Queries.GetBookById;
using Application.Book.Queries.GetBookByKeyWord;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
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

        public Task<Book?> BookDetails(int id)
        {
            throw new NotImplementedException();
        }

        async Task<List<T>> IBookRepository.GetAllBooks<T>()
        {
            var baseQuery = await _dbContext.Books
                .Select(item => new GetAllBooksDTO()
                {
                    Title = item.Title,
                    Author = item.AuthorName
                }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }


        T IBookRepository.GetBookById<T>(int id)
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


        List<T> IBookRepository.GetBookByKeyWord<T>(string keyWord)
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

        List<T> IBookRepository.GetBookByAuthor<T>(string name)
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

        List<T> IBookRepository.GetBookByCategory<T>(string category)
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
