using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemById
{
    public class GetLibraryItemByIdQuery : IRequest<GetLibraryItemByIdDTO>
    {
        public Guid Id { get; set; }
    }
}
