using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemById
{
    public class GetLibraryItemByIdQuery : IRequest<GetLibraryItemByIdDTO>
    {
        public int Id { get; set; }
    }
}
