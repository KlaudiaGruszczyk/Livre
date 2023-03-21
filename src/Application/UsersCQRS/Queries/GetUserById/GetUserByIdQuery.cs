using MediatR;

namespace Application.UsersCQRS.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDTO>
    {
        public Guid Id { get; set; }
    }
}
