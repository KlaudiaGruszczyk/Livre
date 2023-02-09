using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.AuthorsCQRS.Queries.GetAuthorByName
{
    public class GetAuthorByNameHandler : IRequestHandler<GetAuthorByNameQuery, List<GetAuthorByNameDTO>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetAuthorByNameHandler(IAuthorRepository authorRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<List<GetAuthorByNameDTO>> Handle(GetAuthorByNameQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _authorRepository.GetAuthorByName<GetAuthorByNameDTO>(request.Name);
            return _mapper.Map<List<GetAuthorByNameDTO>>(baseQuery);
        }
    }
}
