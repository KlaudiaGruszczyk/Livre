using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByBook
{
    public class GetLibraryItemsByBookQuery : IRequest<List<GetLibraryItemsByBookDTO>>
    {
        public Guid Id { get; set; }
    }
}
