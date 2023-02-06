using Application.Book.Queries;
using Application.Book.Queries.GetAllBooks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace Application.Book.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        public GetAllBooksHandler(IBookRepository bookRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _bookRepository= bookRepository;
            _mapper = mapper;
            _dbContext= dbContext;
        }
        public async Task<IEnumerable<GetAllBooksDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _bookRepository.GetAllBooks();
            return _mapper.Map<IEnumerable<GetAllBooksDTO>>(baseQuery);
            
            
        }
    }
}
