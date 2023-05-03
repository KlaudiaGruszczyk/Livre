using MediatR;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorPhoto
{
    public class UpdateAuthorPhotoCommand : IRequest<string>
    {
        public Guid AuthorId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
