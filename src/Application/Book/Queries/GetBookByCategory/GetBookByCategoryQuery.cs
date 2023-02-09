using Application.Book.Queries.GetBookByKeyWord;
using MediatR;

namespace Application.Book.Queries.GetBookByCategory
{
    public class GetBookByCategoryQuery : IRequest<List<GetBookByCategoryDTO>>
    {
        public string Category { get; set; }
    }
    
}
