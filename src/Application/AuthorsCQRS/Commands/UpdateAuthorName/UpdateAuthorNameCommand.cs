using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorName
{
    public class UpdateAuthorNameCommand : IRequest<string>
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
    }
}
