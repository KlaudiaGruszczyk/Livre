using Application.Common.Interfaces;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByBook
{
    public class GetLibraryItemsByBookHandler : IRequestHandler<GetLibraryItemsByBookQuery, List<GetLibraryItemsByBookDTO>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibraryItemsByBookHandler(IApplicationDbContext dbContext, ILibraryRepository libraryRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLibraryItemsByBookDTO>> Handle(GetLibraryItemsByBookQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _libraryRepository.GetLibraryItemsByBook<GetLibraryItemsByBookDTO>(request.Id);
            return _mapper.Map<List<GetLibraryItemsByBookDTO>>(baseQuery);
        }
    }
}
