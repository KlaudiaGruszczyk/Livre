using MediatR;

namespace Application.AuthorsCQRS.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<Guid>
    {
        public Guid AuthorId { get; set; }
    }
}
