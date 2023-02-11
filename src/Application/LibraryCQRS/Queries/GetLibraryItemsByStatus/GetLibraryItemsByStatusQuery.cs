using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByStatus
{
    public class GetLibraryItemsByStatusQuery : IRequest<GetLibraryItemsByStatusDTO>
    {
        public ReadingStatus Status { get; set; }
    }
}

