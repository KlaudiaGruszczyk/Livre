﻿using Application.AuthorsCQRS.Commands.CreateAuthor;
using Application.AuthorsCQRS.Commands.DeleteAuthor;
using Application.AuthorsCQRS.Commands.UpdateAuthor;
using Application.AuthorsCQRS.Queries.GetAllAuthors;
using Application.AuthorsCQRS.Queries.GetAuthorById;
using Application.AuthorsCQRS.Queries.GetAuthorByName;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthorController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IAuthorRepository _authorRepository;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult> GetAllAuthors()
        {
            var query = new GetAllAuthorsQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAuthorById")]
        public async Task<ActionResult> GetAuthorById([FromQuery] Guid id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery { Id = id }));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetAuthorByName")]
        public async Task<ActionResult> GetAuthorByName([FromQuery] string name)
        {
            return Ok(await Mediator.Send(new GetAuthorByNameQuery { Name = name }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult> UpdateAuthor([FromQuery] Guid id, UpdateAuthorCommand command)
        {
            if (id != command.AuthorId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<Guid>> CreateAuthor(CreateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<int>> DeleteAuthor(Guid id)
        {
            var result = await Mediator.Send(new DeleteAuthorCommand { AuthorId = id });
            return Ok(result);
        }


    }
}
