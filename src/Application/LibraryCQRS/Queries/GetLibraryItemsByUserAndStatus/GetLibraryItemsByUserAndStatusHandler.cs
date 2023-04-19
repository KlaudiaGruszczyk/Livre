using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUserAndStatus
{
    public class GetLibraryItemsByUserAndStatusHandler : IRequestHandler<GetLibraryItemsByUserAndStatusQuery, List<GetLibraryItemsByUserAndStatusDTO>>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetLibraryItemsByUserAndStatusHandler(ILibraryRepository libraryRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<GetLibraryItemsByUserAndStatusDTO>> Handle(GetLibraryItemsByUserAndStatusQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _libraryRepository.GetLibraryItemsByUserAndStatus<GetLibraryItemsByUserAndStatusDTO>(request.UserId, request.ReadingStatus);
            return baseQuery.ToList();
        }
    }
}
