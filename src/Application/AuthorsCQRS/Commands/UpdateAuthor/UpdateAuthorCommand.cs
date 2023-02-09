using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<int>
    {
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

    }
}



