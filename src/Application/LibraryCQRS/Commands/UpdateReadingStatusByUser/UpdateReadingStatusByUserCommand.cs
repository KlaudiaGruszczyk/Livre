using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Commands.UpdateReadingStatusByUser
{
    public class UpdateReadingStatusByUserCommand :IRequest<Guid>
    {
        public Guid LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public Guid BookId { get; set; }
    }
}
