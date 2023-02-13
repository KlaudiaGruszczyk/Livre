using Application.Common.Interfaces;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.UsersCQRS.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IApplicationDbContext dbContext, IMapper mapper)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetAllUsersDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = await _userRepository.GetAllUsers<GetAllUsersDTO>();
            return _mapper.Map<List<GetAllUsersDTO>>(baseQuery);


        }
    }
}
