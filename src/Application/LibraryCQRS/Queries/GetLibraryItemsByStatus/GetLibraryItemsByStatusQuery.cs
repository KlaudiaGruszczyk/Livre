using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByStatus
{
    public class GetLibraryItemsByStatusQuery : IRequest<IList<GetLibraryItemsByStatusDTO>>
    {
        public ReadingStatus Status { get; set; }
    }
}

