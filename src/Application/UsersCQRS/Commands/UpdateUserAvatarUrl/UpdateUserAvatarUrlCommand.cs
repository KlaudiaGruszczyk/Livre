using MediatR;

namespace Application.UsersCQRS.Commands.UpdateUserAvatarUrl
{
    public class UpdateUserAvatarUrlCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string AvatarUrl { get; set; }
    }
}
