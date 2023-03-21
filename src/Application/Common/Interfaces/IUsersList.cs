using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface IUsersList
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
