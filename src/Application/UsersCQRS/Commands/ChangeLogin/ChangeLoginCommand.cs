using MediatR;


namespace Application.UsersCQRS.Commands.ChangeLogin
{
    public class ChangeLoginCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
    }
}
