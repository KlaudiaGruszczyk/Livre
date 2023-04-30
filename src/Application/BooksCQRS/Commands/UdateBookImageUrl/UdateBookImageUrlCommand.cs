using MediatR;

namespace Application.BooksCQRS.Commands.UdateBookImageUrl
{
    public class UpdateBookImageUrlCommand :  IRequest<string>
    {
        public Guid BookId { get; set; }
        public string ImageUrl { get; set; }
    }
}
