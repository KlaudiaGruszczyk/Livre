using MediatR;

namespace Application.LibraryCQRS.Commands.DeleteLibraryItemByUser
{
    public class DeleteLibraryItemByUserCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid LibraryItemId { get; set; }
    }
}
