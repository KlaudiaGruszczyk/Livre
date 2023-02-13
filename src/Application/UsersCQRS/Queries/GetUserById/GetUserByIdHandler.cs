using Application.Common.Interfaces;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.UsersCQRS.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IApplicationDbContext dbContext, IMapper mapper)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetUserByIdDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _userRepository.GetUserById<GetUserByIdDTO>(request.Id);
            return _mapper.Map<GetUserByIdDTO>(baseQuery);
        }
    }
}
