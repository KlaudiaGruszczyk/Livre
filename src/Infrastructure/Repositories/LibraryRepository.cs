using Application.Common.Interfaces;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.LibraryCQRS.Queries.GetLibraryItemsByStatus;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUserAndStatus;
using Application.UsersCQRS.Queries.GetAllUsers;
using Application.UsersCQRS.Queries.GetUserById;
using AutoMapper;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        public LibraryRepository(IMapper mapper, IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<T>> GetAllLibraryItems<T>()
        {
            var baseQuery = await _dbContext.UsersLibraryItems
               .Select(item => new GetAllLibraryItemsDTO()
               {
                   LibraryItemId = item.LibraryItemId,
                   ReadingStatus = item.ReadingStatus,
                   UserId= item.UserId,
                   BookIdI= item.BookId
               }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }

        public T GetLibraryItemById<T>(Guid id)
        {
            var baseQuery = _dbContext.UsersLibraryItems
                .Where(item => item.LibraryItemId == id)
                .Select(item => new GetLibraryItemByIdDTO()
                 {
                    LibraryItemId = item.LibraryItemId,
                    ReadingStatus = item.ReadingStatus,
                    UserId = item.UserId,
                    BookId = item.BookId
                 }).OfType<T>()
                   .FirstOrDefault();

            return baseQuery;
        }

        public List<T> GetLibraryItemsByBook<T>(Guid bookId)
        {
            var baseQuery = _dbContext.UsersLibraryItems
                .Where(item => item.BookId == bookId)
                .Select(item => new GetLibraryItemsByBookDTO()
                {
                    LibraryItemId = item.LibraryItemId,
                    ReadingStatus = item.ReadingStatus,
                    UserId = item.UserId,
                    BookId = item.BookId
                }).OfType<T>()
                 .ToList();

            return baseQuery;
        }

        public List<T> GetLibraryItemsByStatus<T>(ReadingStatus status)
        {
            var baseQuery = _dbContext.UsersLibraryItems
             .Where(item => item.ReadingStatus == status).AsEnumerable();

            return baseQuery.OfType<T>().ToList();
        }

        public List<T> GetLibraryItemsByUser<T>(Guid userId)
        {
            var baseQuery = _dbContext.UsersLibraryItems
                .Where(item => item.UserId == userId)
                .Include(book => book.Book)
                .Select(item => new GetLibraryItemsByUserDTO()
                {
                    ReadingStatus = item.ReadingStatus,
                    Title = item.Book.Title,
                    BookId = item.BookId
                }).OfType<T>()
                 .ToList();

            return baseQuery;
        }

        public List<T> GetLibraryItemsByUserAndStatus<T> (Guid userId, ReadingStatus status)
        {
            var baseQuery = _dbContext.UsersLibraryItems
                .Where(item => item.UserId == userId && item.ReadingStatus == status)
                .Include(book => book.Book)
                .Select(item => new GetLibraryItemsByUserAndStatusDTO()
                {
                    LibraryItemId = item.LibraryItemId,
                    ReadingStatus = item.ReadingStatus,
                    UserId = item.UserId,
                    BookId = item.BookId,
                    Title = item.Book.Title
                }).OfType<T>()
                 .ToList();

            return baseQuery;
        }
    }
}
