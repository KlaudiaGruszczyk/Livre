using Application.Common.Interfaces;
using Domain.Enums;

namespace Application.UsersCQRS.Queries.GetAllUsers
{
    public class GetAllUsersDTO : IUsersList
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
