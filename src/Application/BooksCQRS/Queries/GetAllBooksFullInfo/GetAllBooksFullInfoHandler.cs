using Application.BooksCQRS.Queries.GetAllBooks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.BooksCQRS.Queries.GetAllBooksFullInfo
{
    public class GetAllBooksFullInfoHandler : IRequestHandler<GetAllBooksFullInfoQuery, IEnumerable<GetAllBooksFullInfoDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        public GetAllBooksFullInfoHandler(IBookRepository bookRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<GetAllBooksFullInfoDTO>> Handle(GetAllBooksFullInfoQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _bookRepository.GetAllBooksFullInfo<GetAllBooksFullInfoDTO>();
            return _mapper.Map<IEnumerable<GetAllBooksFullInfoDTO>>(baseQuery);
        }
    }
}
