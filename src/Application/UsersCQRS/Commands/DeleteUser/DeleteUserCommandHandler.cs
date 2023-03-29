using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
       

        public DeleteUserCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task<Guid> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefaultAsync();
            if (user == null) return default;
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return (Guid)user.UserId;
        }
    }
    
}
