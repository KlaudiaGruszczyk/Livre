using Application.Book.Queries.GetAllBooks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<GetAllAuthorsDTO>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetAllAuthorsHandler(IAuthorRepository authorRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<GetAllAuthorsDTO>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _authorRepository.GetAllAuthors<GetAllAuthorsDTO>();
            return _mapper.Map<IEnumerable<GetAllAuthorsDTO>>(baseQuery);
        }
    }
}
