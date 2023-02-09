
using MediatR;

namespace Application.Book.Queries.GetBookByKeyWord
{
    public class GetBookByKeyWordQuery : IRequest<List<GetBookByKeyWordDTO>>
    {
        public string KeyWord { get; set; }
    }
}
