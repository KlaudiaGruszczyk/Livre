using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUserAndStatus
{
    public class GetLibraryItemsByUserAndStatusQuery : IRequest<List<GetLibraryItemsByUserAndStatusDTO>>
    {
        public Guid UserId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
    }
}
