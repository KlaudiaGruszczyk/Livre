
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Book.Queries.GetBookByKeyWord
{
    public class GetBookByKeyWordHandler : IRequestHandler<GetBookByKeyWordQuery, List<GetBookByKeyWordDTO>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;



        public GetBookByKeyWordHandler(IApplicationDbContext dbContext, IBookRepository bookRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<GetBookByKeyWordDTO>> Handle(GetBookByKeyWordQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _bookRepository.GetBookByKeyWord<GetBookByKeyWordDTO>(request.KeyWord);
            return _mapper.Map<List<GetBookByKeyWordDTO>>(baseQuery);
        }
    }
}
