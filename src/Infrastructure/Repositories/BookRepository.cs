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
        public Task<Book> Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> BookDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var baseQuery = await _dbContext.Books
                .Include(r => r.Title)
                .Include(r => r.Author.Name)
                .ToListAsync();

            return baseQuery;
        }

        public Task<Book?> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book?>> GetBookByTitle(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
