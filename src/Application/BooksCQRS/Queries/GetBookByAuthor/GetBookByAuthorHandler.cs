using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.BooksCQRS.Queries.GetBookByAuthor
{
    public class GetBookByAuthorHandler : IRequestHandler<GetBookByAuthorQuery, List<GetBookByAuthorDTO>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByAuthorHandler(IApplicationDbContext dbContext, IBookRepository bookRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<GetBookByAuthorDTO>> Handle(GetBookByAuthorQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _bookRepository.GetBookByAuthor<GetBookByAuthorDTO>(request.AuthorId);
            return _mapper.Map<List<GetBookByAuthorDTO>>(baseQuery);
        }
    }
}
