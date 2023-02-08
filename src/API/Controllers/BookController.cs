using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Book.Queries.GetAllBooks;
using MediatR;
using Domain.Repositories;
using Application.Book.Commands.CreateBook;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class BookController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IBookRepository _bookRepository;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        public BookController(IBookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult> UpdateBook([FromQuery] int id, UpdateBookCommand command)
        {
            if (id != command.BookId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<int>> CreateBook(CreateBookCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<int>> DeleteBook(int id)
        { 
           var result = await Mediator.Send(new DeleteBookCommand { BookId = id } ); 
            return Ok(result);
        }
    }
}
