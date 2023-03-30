using Application.BooksCQRS.Commands.CreateBook;
using Application.BooksCQRS.Commands.DeleteBook;
using Application.BooksCQRS.Commands.UpdateBook;
using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetBookByAuthor;
using Application.BooksCQRS.Queries.GetBookByCategory;
using Application.BooksCQRS.Queries.GetBookById;
using Application.BooksCQRS.Queries.GetBookByKeyWord;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    
    public class BookController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IBookRepository _bookRepository;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAllBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetBookById")]
        public async Task<ActionResult> GetBookById([FromQuery] Guid id)
        {
            return Ok(await Mediator.Send(new GetBookByIdQuery { Id = id }));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetBookByKeyWord")]
        public async Task<ActionResult> GetBookByKeyWord([FromQuery] string keyWord)
        {
            return Ok(await Mediator.Send(new GetBookByKeyWordQuery { KeyWord = keyWord }));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetBookByAuthor")]
        public async Task<ActionResult> GetBookByAuthor([FromQuery] string name)
        {
            return Ok(await Mediator.Send(new GetBookByAuthorQuery { Name = name }));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetBookByCategory")]
        public async Task<ActionResult> GetBookByCategory([FromQuery] string category)
        {
            return Ok(await Mediator.Send(new GetBookByCategoryQuery { Category = category }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBook")]
        public async Task<ActionResult> UpdateBook([FromQuery] Guid id, UpdateBookCommand command)
        {
            if (id != command.BookId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateBook")]
        public async Task<ActionResult<int>> CreateBook(CreateBookCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<int>> DeleteBook(Guid id)
        {
            var result = await Mediator.Send(new DeleteBookCommand { BookId = id });
            return Ok(result);
        }


    }
}
