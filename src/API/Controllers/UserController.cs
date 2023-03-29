using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.UsersCQRS.Commands.CreateUser;
using Application.UsersCQRS.Queries.GetAllUsers;
using Application.UsersCQRS.Queries.GetUserByEmail;
using Application.UsersCQRS.Queries.GetUserById;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult> GetUserById([FromQuery] Guid id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        [HttpGet("GetUserByEmail")]

        public async Task<ActionResult> GetUserByEmail([FromQuery] string email)
        {
            return Ok(await Mediator.Send(new GetUserByEmailQuery { Email = email }));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
