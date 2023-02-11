using Application.Common.Interfaces;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.LibraryCQRS.Queries.GetLibraryItemsByStatus;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
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
                   UserIdItem= item.UserIdItem,
                   BookIdItem= item.BookIdItem
               }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }

        public T GetLibraryItemById<T>(int id)
        {
            var baseQuery = _dbContext.UsersLibraryItems
        .Where(item => item.LibraryItemId == id)
        .Select(item => new GetLibraryItemByIdDTO()
        {
           LibraryItemId = item.LibraryItemId,
           ReadingStatus = item.ReadingStatus,
           UserIdItem= item.UserIdItem,
           BookIdItem= item.BookIdItem
        }).OfType<T>()
            .FirstOrDefault();

            return baseQuery;
        }

        public List<T> GetLibraryItemsByBook<T>(int bookId)
        {
            var baseQuery = _dbContext.UsersLibraryItems
                .Where(item => item.BookIdItem == bookId)
                .Select(item => new GetLibraryItemsByBookDTO()
                {
                    LibraryItemId = item.LibraryItemId,
                    ReadingStatus = item.ReadingStatus,
                    UserIdItem = item.UserIdItem,
                    BookIdItem = item.BookIdItem
                }).OfType<T>()
                 .ToList();

            return baseQuery;
        }

        public List<T> GetLibraryItemsByStatus<T>(ReadingStatus status)
        {
            var baseQuery = _dbContext.UsersLibraryItems
             .Where(item => item.ReadingStatus == status)
             .Select(item => new GetLibraryItemsByStatusDTO()
             {
                 LibraryItemId = item.LibraryItemId,
                 ReadingStatus = item.ReadingStatus,
                 UserIdItem = item.UserIdItem,
                 BookIdItem = item.BookIdItem
             }).AsEnumerable();

            return baseQuery.OfType<T>().ToList();
        }

        public List<T> GetLibraryItemsByUser<T>(int userId)
        {
            var baseQuery = _dbContext.UsersLibraryItems
                .Where(item => item.UserIdItem == userId)
                .Select(item => new GetLibraryItemsByUserDTO()
                {
                    LibraryItemId = item.LibraryItemId,
                    ReadingStatus = item.ReadingStatus,
                    UserIdItem = item.UserIdItem,
                    BookIdItem = item.BookIdItem
                }).OfType<T>()
                 .ToList();

            return baseQuery;
        }
    }
}
