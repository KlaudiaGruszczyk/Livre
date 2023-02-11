using Application.BooksCQRS.Queries.GetBookById;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByStatus
{

    public class GetLibraryItemsByStatusHandler : IRequestHandler<GetLibraryItemsByStatusQuery, GetLibraryItemsByStatusDTO>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetLibraryItemsByStatusHandler(ILibraryRepository libraryRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<GetLibraryItemsByStatusDTO> Handle(GetLibraryItemsByStatusQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _libraryRepository.GetLibraryItemsByStatus<GetLibraryItemsByStatusDTO>(request.Status);
            return _mapper.Map<GetLibraryItemsByStatusDTO>(baseQuery);
        }

    }
}
