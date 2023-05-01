using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersCQRS.Commands.ActivateUser
{
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        public ActivateUserCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

            public async Task<Unit> Handle(ActivateUserCommand command, CancellationToken cancellationToken)
            {
                var activationLink = await _dbContext.ActivationLinks.Include(al => al.User).SingleOrDefaultAsync(al => al.Id == command.Token, cancellationToken);

                if (activationLink == null)
                {
                    throw new ArgumentException("Invalid activation token.");
                }

                if (activationLink.ExpirationDate <= DateTime.UtcNow)
                {
                    throw new ArgumentException("Activation token has expired.");
                }

                var user = activationLink.User;
                user.IsActivated = true;

                _dbContext.Users.Update(user);
                _dbContext.ActivationLinks.Remove(activationLink);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }

