using MediatR;

namespace Application.UsersCQRS.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDTO>
    {
        public int Id { get; set; }
    }
}
