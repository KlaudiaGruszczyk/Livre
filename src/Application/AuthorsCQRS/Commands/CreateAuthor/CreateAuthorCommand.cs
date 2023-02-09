using MediatR;

namespace Application.AuthorsCQRS.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
