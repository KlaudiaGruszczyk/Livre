using Application.Common.Interfaces;
using Application.UsersCQRS.Queries.GetAllUsers;
using Application.UsersCQRS.Queries.GetUserByEmail;
using Application.UsersCQRS.Queries.GetUserById;
using AutoMapper;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public UserRepository(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAllUsers<T>()
        {
            var baseQuery = await _dbContext.Users
               .Select(item => new GetAllUsersDTO()
               {
                   UserId = item.UserId,
                   Login = item.Login,
                   Password = item.Password,
                   Email = item.Email,
                   Role = item.Role
               }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }

        public T GetUserByEmail<T>(string email)
        {
            var baseQuery = _dbContext.Users
              .Where(item => item.Email.Contains(email))
              .Select(item => new GetUserByEmailDTO()
              {
                Login = item.Login,
                Password = item.Password,
                Email = item.Email,
                Role = item.Role
              }).OfType<T>()
                .FirstOrDefault();

            return baseQuery;
        }

        public T GetUserById<T>(Guid id)
        {
            var baseQuery = _dbContext.Users
            .Where(item => item.UserId==id)
            .Select(item => new GetUserByIdDTO()
            {
                UserId =item.UserId,
                Login = item.Login,
                Password = item.Password,
                Email = item.Email,
                Role = item.Role,
                AvatarUrl = item.AvatarUrl
            }).OfType<T>()
                .FirstOrDefault();

            return baseQuery;
        }
    }
}
