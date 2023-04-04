using Application.Common.Interfaces;
using Application.UsersCQRS.Commands.RegisterUser;
using FluentValidation;
using MediatR;

namespace Application.UsersCQRS.Commands.ChangeLogin
{
    public class ChangeLoginCommandHandler : IRequestHandler<ChangeLoginCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;

        public ChangeLoginCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(ChangeLoginCommand command, CancellationToken cancellationToken)
        {
            var validator = new ChangeLoginCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = _dbContext.Users.Where(a => a.UserId == command.UserId).FirstOrDefault();

            if (user == null)
            {
                return default;
            }
            else
            {
                user.Login = command.Login;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user.Login;
            }
        }
    }
}
