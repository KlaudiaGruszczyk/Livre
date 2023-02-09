using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.AuthorsCQRS.Queries.GetAuthorById
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdDTO>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<GetAuthorByIdDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _authorRepository.GetAuthorById<GetAuthorByIdDTO>(request.Id);
            return _mapper.Map<GetAuthorByIdDTO>(baseQuery);
        }
    }
}
