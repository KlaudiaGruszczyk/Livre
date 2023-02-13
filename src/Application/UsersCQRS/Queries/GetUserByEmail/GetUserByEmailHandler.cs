using Application.BooksCQRS.Queries.GetBookByKeyWord;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.UsersCQRS.Queries.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, GetUserByEmailDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByEmailHandler(IUserRepository userRepository, IApplicationDbContext dbContext, IMapper mapper)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetUserByEmailDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _userRepository.GetUserByEmail<GetUserByEmailDTO>(request.Email);
            return _mapper.Map<GetUserByEmailDTO>(baseQuery);
        }
    }
}
