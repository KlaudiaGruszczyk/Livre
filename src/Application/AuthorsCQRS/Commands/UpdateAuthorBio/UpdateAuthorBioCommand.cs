using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorBio
{
    public class UpdateAuthorBioCommand : IRequest<string>
    {
        public Guid AuthorId { get; set; }
        public string Bio { get; set; }
    }
}
