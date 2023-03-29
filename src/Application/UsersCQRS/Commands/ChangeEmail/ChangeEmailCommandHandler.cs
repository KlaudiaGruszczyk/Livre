using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        public ChangeEmailCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.Where(a => a.UserId== command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.Email = command.Email;
                await _dbContext.SaveChangesAsync();
                return user.Email;
            }
        }
    }
}
