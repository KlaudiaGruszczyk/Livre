using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.BooksCQRS.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        public GetAllBooksHandler(IBookRepository bookRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<GetAllBooksDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _bookRepository.GetAllBooks<GetAllBooksDTO>();
            return _mapper.Map<IEnumerable<GetAllBooksDTO>>(baseQuery);


        }
    }
}
