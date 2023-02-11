using Application.BooksCQRS.Queries.GetBookById;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemById
{
    public class GetLibraryItemByIdHandler : IRequestHandler<GetLibraryItemByIdQuery, GetLibraryItemByIdDTO>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetLibraryItemByIdHandler(ILibraryRepository libraryRepository, IMapper mapper, IApplicationDbContext dbContext)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetLibraryItemByIdDTO> Handle(GetLibraryItemByIdQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _libraryRepository.GetLibraryItemById<GetLibraryItemByIdDTO>(request.Id);
            return _mapper.Map<GetLibraryItemByIdDTO>(baseQuery);
        }

    }

}
