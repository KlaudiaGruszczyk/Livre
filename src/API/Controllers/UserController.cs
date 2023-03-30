using Application.BooksCQRS.Commands.DeleteBook;
using Application.BooksCQRS.Commands.UpdateBook;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.UsersCQRS.Commands.ChangeEmail;
using Application.UsersCQRS.Commands.ChangeLogin;
using Application.UsersCQRS.Commands.ChangePassword;
using Application.UsersCQRS.Commands.CreateUser;
using Application.UsersCQRS.Commands.DeleteUser;
using Application.UsersCQRS.Commands.LoginUser;
using Application.UsersCQRS.Queries.GetAllUsers;
using Application.UsersCQRS.Queries.GetUserByEmail;
using Application.UsersCQRS.Queries.GetUserById;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers
{
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IUserRepository _userRepository;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetUserById")]
        public async Task<ActionResult> GetUserById([FromQuery] Guid id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult> GetUserByEmail([FromQuery] string email)
        {
            return Ok(await Mediator.Send(new GetUserByEmailQuery { Email = email }));
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(LoginUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpPut("UpdateEmail")]
        public async Task<ActionResult> UpdateEmail (ChangeEmailCommand command)
        {
           
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpPut("UpdateLogin")]
        public async Task<ActionResult> UpdateLogin(ChangeLoginCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpPut("UpdatePassword")]
        public async Task<ActionResult> UpdatePassword(ChangePasswordCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<int>> DeleteUser(Guid id)
        {
            var result = await Mediator.Send(new DeleteUserCommand { UserId = id });
            return Ok(result);
        }

    }
}
