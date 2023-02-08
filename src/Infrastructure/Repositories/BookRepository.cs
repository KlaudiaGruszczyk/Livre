
using Application.Book.Queries.GetAllBooks;
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
            _mapper= mapper;
            _dbContext= dbContext;
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


            public Task<Book?> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book?>> GetBookByTitle(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
