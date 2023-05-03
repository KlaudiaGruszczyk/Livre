using MediatR;

namespace Application.AuthorsCQRS.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Bio { get; set; }

        public string PhotoUrl { get; set; }
    }
}
