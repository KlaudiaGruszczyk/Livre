using Application.Common.Interfaces;
using Domain.Enums;

namespace Application.UsersCQRS.Queries.GetUserById
{
    public class GetUserByIdDTO : IUserDetails
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string AvatarUrl { get; set; }

    }
}
