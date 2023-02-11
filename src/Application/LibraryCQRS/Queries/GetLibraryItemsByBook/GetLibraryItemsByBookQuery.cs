using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByBook
{
    public class GetLibraryItemsByBookQuery : IRequest<List<GetLibraryItemsByBookDTO>>
    {
        public int Id { get; set; }
    }
}
