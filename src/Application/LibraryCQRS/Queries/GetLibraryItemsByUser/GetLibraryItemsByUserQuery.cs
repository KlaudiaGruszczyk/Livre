using MediatR;

namespace Application.LibraryCQRS.Queries.GetLibraryItemsByUser
{
    public class GetLibraryItemsByUserQuery : IRequest<List<GetLibraryItemsByUserDTO>>
    {
        public int Id { get; set; }
    }
}
