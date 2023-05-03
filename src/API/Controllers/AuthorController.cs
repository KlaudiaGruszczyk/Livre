using Application.AuthorsCQRS.Commands.CreateAuthor;
using Application.AuthorsCQRS.Commands.DeleteAuthor;
using Application.AuthorsCQRS.Commands.UpdateAuthor;
using Application.AuthorsCQRS.Commands.UpdateAuthorBio;
using Application.AuthorsCQRS.Commands.UpdateAuthorName;
using Application.AuthorsCQRS.Commands.UpdateAuthorPhoto;
using Application.AuthorsCQRS.Queries.GetAllAuthors;
using Application.AuthorsCQRS.Queries.GetAuthorById;
using Application.AuthorsCQRS.Queries.GetAuthorByName;
using Application.BooksCQRS.Commands.UpdateBookPdfUrl;
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
        [AllowAnonymous]
       // [Authorize(Roles = "Admin")]
        [HttpGet("GetAuthorById/{id}")]
        public async Task<ActionResult> GetAuthorById([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery { Id = id }));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetAuthorByName")]
        public async Task<ActionResult> GetAuthorByName([FromQuery] string name)
        {
            return Ok(await Mediator.Send(new GetAuthorByNameQuery { Name = name }));
        }

        [AllowAnonymous]
       // [Authorize(Roles = "Admin")]
        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
           
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateAuthorName")]
        public async Task<ActionResult> UpdateAuthorName(UpdateAuthorNameCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

 

        [AllowAnonymous]
        //Authorize(Roles = "Admin")]
        [HttpPut("UpdateAuthorBio")]
        public async Task<ActionResult> UpdateAuthorBio(UpdateAuthorBioCommand command)
        {

            return Ok(await Mediator.Send(command));
        }
        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateAuthorPhotoUrl")]
        public async Task<ActionResult> UpdateAuthorPhotoUrl(UpdateAuthorPhotoCommand command)
        {
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
