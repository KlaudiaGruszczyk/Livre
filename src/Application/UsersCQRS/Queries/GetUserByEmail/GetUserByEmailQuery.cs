using MediatR;

namespace Application.UsersCQRS.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<GetUserByEmailDTO>
    {
        public string Email { get; set; }
    }
}
