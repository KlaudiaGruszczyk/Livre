using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Commands.AddLibraryItemByUser
{
    public class AddLibraryItemByUserCommand : IRequest<Guid>
    {
        public Guid BookId { get; set; }
    }
}
