using Application.Book.Queries;
using Application.Book.Queries.GetAllBooks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace Application.Book.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<GetAllBooksDTO>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<GetAllBooksDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _dbContext.Books();
            
        }
    }
}
