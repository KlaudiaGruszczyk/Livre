using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Book.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdDTO>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;



        public GetBookByIdHandler(IApplicationDbContext dbContext, IBookRepository bookRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetBookByIdDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _bookRepository.GetBookById<GetBookByIdDTO>(request.Id);
            return _mapper.Map<GetBookByIdDTO>(baseQuery);
        }
    }
}
