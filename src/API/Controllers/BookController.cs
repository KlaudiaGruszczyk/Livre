using Application.BooksCQRS.Commands.CreateBook;
using Application.BooksCQRS.Commands.DeleteBook;
using Application.BooksCQRS.Commands.UpdateBook;
using Application.BooksCQRS.Commands.UpdateBookAuthor;
using Application.BooksCQRS.Commands.UpdateBookCategory;
using Application.BooksCQRS.Commands.UpdateBookDescription;
using Application.BooksCQRS.Commands.UpdateBookPdfUrl;
using Application.BooksCQRS.Commands.UdateBookImageUrl;

using Application.BooksCQRS.Commands.UpdateBookPublishedDate;
using Application.BooksCQRS.Commands.UpdateBookPublisher;
using Application.BooksCQRS.Commands.UpdateBookTitle;
using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetAllBooksFullInfo;
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
    [ApiController]
    [Route("[controller]")]

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


        [HttpGet("GetAllBooksFullInfo")]
        public async Task<ActionResult> GetAllBooksFullInfo()
        {
            var query = new GetAllBooksFullInfoQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult> GetBookById([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetBookByIdQuery { Id = id }));
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetBookByKeyWord")]
        public async Task<ActionResult> GetBookByKeyWord([FromQuery] string keyWord)
        {
            return Ok(await Mediator.Send(new GetBookByKeyWordQuery { KeyWord = keyWord }));
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetBooksByAuthor/{id}")]
        public async Task<ActionResult> GetBookByAuthor([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetBookByAuthorQuery { AuthorId = id }));
        }

        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpGet("GetBookByCategory")]
        public async Task<ActionResult> GetBookByCategory([FromQuery] string category)
        {
            return Ok(await Mediator.Send(new GetBookByCategoryQuery { Category = category }));
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult> UpdateBook([FromRoute] Guid id, [FromBody] UpdateBookCommand command)
        {
            command.BookId = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookPdfUrl")]
        public async Task<ActionResult> UpdateBookPdfUrl(UpdateBookPdfUrlCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookImgUrl")]
        public async Task<ActionResult> UpdateBookImageUrl(UpdateBookImageUrlCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookTitle")]
        public async Task<ActionResult> UpdateBookImgUrl(UpdateBookTitleCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookAuthor")]
        public async Task<ActionResult> UpdateBookAuthor( UpdateBookAuthorNameCommand command)
        {
           
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookPublishedDate")]
        public async Task<ActionResult> UpdateBookPublishedDate(UpdateBookPublishedDateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookPublisher")]
        public async Task<ActionResult> UpdateBookPublisher(UpdateBookPublisherCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookCategory")]
        public async Task<ActionResult> UpdateBookCategory(UpdateBookCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBookDescription")]
        public async Task<ActionResult> UpdateBookDescription(UpdateBookDescriptionCommand command)
        { 
            return Ok(await Mediator.Send(command));
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateBook")]
        public async Task<ActionResult<int>> CreateBook(CreateBookCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult<int>> DeleteBook([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new DeleteBookCommand { BookId = id });
            return Ok(result);
        }


    }
}
