using MediatR;

namespace Application.BooksCQRS.Queries.GetBookByCategory
{
    public class GetBookByCategoryQuery : IRequest<List<GetBookByCategoryDTO>>
    {
        public string Category { get; set; }
    }

}
