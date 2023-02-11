using Application.BooksCQRS.Queries.GetAllBooks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;
namespace Application.LibraryCQRS.Queries.GetAllLibraryItems
{
    public class GetAllLibraryItemsHandler : IRequestHandler<GetAllLibraryItemsQuery, IEnumerable<GetAllLibraryItemsDTO>>
    {

        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetAllLibraryItemsHandler(ILibraryRepository libraryRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _libraryRepository= libraryRepository;
            _mapper= mapper;
            _dbContext= dbContext;
        }

        public async Task<IEnumerable<GetAllLibraryItemsDTO>> Handle(GetAllLibraryItemsQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _libraryRepository.GetAllLibraryItems<GetAllLibraryItemsDTO>();
            return _mapper.Map<IEnumerable<GetAllLibraryItemsDTO>>(baseQuery);


        }
    }
}
