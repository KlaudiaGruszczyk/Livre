using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using Application.Authors.Queries.GetAuthorByName;
using Application.Book.Commands.CreateBook;
using Application.Book.Queries.GetAllBooks;
using Application.Book.Queries.GetBookById;
using Application.Book.Queries.GetBookByKeyWord;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthorController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IAuthorRepository _authorRepository;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public AuthorController( IAuthorRepository authorRepository)
        {
            _authorRepository= authorRepository;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult> GetAllAuthors()
        {
            var query = new GetAllAuthorsQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAuthorById")]
        public async Task<ActionResult> GetAuthorById([FromQuery] int id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery { Id = id }));
        }


        [HttpGet("GetAuthorByName")]
        public async Task<ActionResult> GetAuthorByName([FromQuery] string name)
        {
            return Ok(await Mediator.Send(new GetAuthorByNameQuery { Name = name }));
        }

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult> UpdateAuthor([FromQuery] int id, UpdateAuthorCommand command)
        {
            if (id != command.AuthorId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<int>> CreateAuthor(CreateAuthorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<int>> DeleteAuthor(int id)
        {
            var result = await Mediator.Send(new DeleteAuthorCommand { AuthorId = id });
            return Ok(result);
        }

       
    }
}
