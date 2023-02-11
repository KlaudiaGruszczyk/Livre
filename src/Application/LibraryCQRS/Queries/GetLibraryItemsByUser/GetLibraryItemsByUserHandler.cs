using Application.BooksCQRS.Queries.GetBookByCategory;
using Application.Common.Interfaces;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUser
{
    public class GetLibraryItemsByUserHandler : IRequestHandler<GetLibraryItemsByUserQuery, List<GetLibraryItemsByUserDTO>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibraryItemsByUserHandler(IApplicationDbContext dbContext, ILibraryRepository libraryRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLibraryItemsByUserDTO>> Handle(GetLibraryItemsByUserQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _libraryRepository.GetLibraryItemsByUser<GetLibraryItemsByUserDTO>(request.Id);
            return _mapper.Map<List<GetLibraryItemsByUserDTO>>(baseQuery);
        }
    }
}
