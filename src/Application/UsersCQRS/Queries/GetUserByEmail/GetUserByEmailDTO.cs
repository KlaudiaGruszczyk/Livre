using Domain.Enums;

namespace Application.UsersCQRS.Queries.GetUserByEmail
{
    public class GetUserByEmailDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

    }
}
