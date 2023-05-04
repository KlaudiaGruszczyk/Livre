using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Application.UsersCQRS.Commands.UpdateUserAvatarUrl
{
    public class UpdateUserAvatarUrlCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string AvatarUrl { get; set; }
    }
}
