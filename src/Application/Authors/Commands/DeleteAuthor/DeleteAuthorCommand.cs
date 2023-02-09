using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<int>
    {
        public int AuthorId { get; set; }
    }
}
