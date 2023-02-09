using Application.AuthorsCQRS.Queries.GetAllAuthors;
using Application.AuthorsCQRS.Queries.GetAuthorById;
using Application.AuthorsCQRS.Queries.GetAuthorByName;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        public AuthorRepository(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        async Task<List<T>> IAuthorRepository.GetAllAuthors<T>()
        {
            var baseQuery = await _dbContext.Authors
                .Select(item => new GetAllAuthorsDTO()
                {
                    Name = item.Name
                }).ToListAsync();

            return baseQuery.Cast<T>().ToList();
        }


        T IAuthorRepository.GetAuthorById<T>(int id)
        {
            var baseQuery = _dbContext.Authors
            .Where(item => item.AuthorId == id)
            .Select(item => new GetAuthorByIdDTO()
            {
                AuthorId = item.AuthorId,
                Name = item.Name,
                Bio = item.Bio

            }).OfType<T>()
        .FirstOrDefault();

            return baseQuery;
        }

        List<T> IAuthorRepository.GetAuthorByName<T>(string keyWord)
        {
            var baseQuery = _dbContext.Authors
        .Where(item => item.Name.Contains(keyWord))
        .Select(item => new GetAuthorByNameDTO()
        {
            Name = item.Name,
            Bio = item.Bio

        }).OfType<T>().ToList();

            return baseQuery;
        }

    }
}

