using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using BC = BCrypt.Net.BCrypt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.CreateUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMediator _mediator;

        public RegisterUserCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }


        public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync((item)=> item.Login == command.Login);
            
            if (user == null) {
                user= new User()
                {
                    UserId = Guid.NewGuid(),
                    Login = command.Login,
                    Password = BC.HashPassword(command.Password),
                    Email = command.Email,
                    Role = command.Role
                };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user.UserId;
            }
            throw new ArgumentException("User already exits", command.Login);
        }
            
    }
}
