using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using BC = BCrypt.Net.BCrypt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using FluentValidation;
using Application.UsersCQRS.Commands.RegisterUser;
using System.ComponentModel.DataAnnotations;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

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
            var validator = new RegisterUserCommandValidator(_dbContext);

            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
            var user = await _dbContext.Users.SingleOrDefaultAsync((item)=> item.Login == command.Login);
            
            if (user == null) {
                user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Login = command.Login,
                    Password = BC.HashPassword(command.Password),
                    Email = command.Email,
                    Role = UserRole.User
                };


                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return user.UserId;
            }
            throw new ArgumentException("User already exits", command.Login);
        }
            
    }
}
