using MediatR;

namespace Application.AuthorsCQRS.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<int>
    {
        public int AuthorId { get; set; }
    }
}
