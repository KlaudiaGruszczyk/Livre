using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Guid>
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

    }
}



