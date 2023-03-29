﻿using Application.BooksCQRS.Commands.DeleteBook;
using Application.BooksCQRS.Commands.UpdateBook;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.UsersCQRS.Commands.ChangeEmail;
using Application.UsersCQRS.Commands.CreateUser;
using Application.UsersCQRS.Commands.DeleteUser;
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
        public async Task<ActionResult> RegisterUser(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateEmail")]
        public async Task<ActionResult> UpdateEmail (ChangeEmailCommand command)
        {
           
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<int>> DeleteUser(Guid id)
        {
            var result = await Mediator.Send(new DeleteUserCommand { UserId = id });
            return Ok(result);
        }

    }
}
