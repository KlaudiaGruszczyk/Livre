using Application.Book.Queries.GetBookByCategory;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Book.Queries.GetBookByCategory
{
    public class GetBookByCategoryHandler : IRequestHandler<GetBookByCategoryQuery, List<GetBookByCategoryDTO>>
    
        {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


    public GetBookByCategoryHandler(IApplicationDbContext dbContext, IBookRepository bookRepository, IMapper mapper)
    {
        _dbContext = dbContext;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<GetBookByCategoryDTO>> Handle(GetBookByCategoryQuery request, CancellationToken cancellationToken)
    {
        var baseQuery = _bookRepository.GetBookByCategory<GetBookByCategoryDTO>(request.Category);
        return _mapper.Map<List<GetBookByCategoryDTO>>(baseQuery);
    }
    
}
}
