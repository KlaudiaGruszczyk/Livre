using Domain.Enums;
using MediatR;

namespace Application.UsersCQRS.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersDTO>>
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
