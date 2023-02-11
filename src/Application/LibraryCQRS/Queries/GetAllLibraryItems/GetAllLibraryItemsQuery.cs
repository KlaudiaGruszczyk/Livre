using Domain.Enums;
using MediatR;

namespace Application.LibraryCQRS.Queries.GetAllLibraryItems
{
    public class GetAllLibraryItemsQuery : IRequest<IEnumerable<GetAllLibraryItemsDTO>>
    {
        public int LibraryItemId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public int? UserIdItem { get; set; }
        public int? BookIdItem { get; set; }
    }
}
