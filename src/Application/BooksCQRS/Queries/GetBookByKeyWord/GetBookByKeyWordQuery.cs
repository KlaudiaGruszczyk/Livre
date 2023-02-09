using MediatR;

namespace Application.BooksCQRS.Queries.GetBookByKeyWord
{
    public class GetBookByKeyWordQuery : IRequest<List<GetBookByKeyWordDTO>>
    {
        public string KeyWord { get; set; }
    }
}
