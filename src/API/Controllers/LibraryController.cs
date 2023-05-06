using Application.BooksCQRS.Commands.CreateBook;
using Application.BooksCQRS.Commands.DeleteBook;
using Application.BooksCQRS.Commands.UpdateBook;
using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetBookById;
using Application.LibraryCQRS.Commands.AddLibraryItemByUser;
using Application.LibraryCQRS.Commands.CreateLibraryItem;
using Application.LibraryCQRS.Commands.DeleteLibraryItem;
using Application.LibraryCQRS.Commands.UpdateLibraryItem;
using Application.LibraryCQRS.Commands.UpdateReadingStatusByUser;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.LibraryCQRS.Queries.GetLibraryItemsByStatus;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUserAndStatus;
using Domain.Enums;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILibraryRepository _libraryRepository;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet("GetAllLibraryItems")]
        public async Task<ActionResult> GetAllLibraryItems()
        {
            var query = new GetAllLibraryItemsQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetLibraryItemById")]
        public async Task<ActionResult> GetLibraryItemById([FromQuery] Guid id)
        {
            return Ok(await Mediator.Send(new GetLibraryItemByIdQuery { Id = id }));
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet("GetLibraryItemsByBook")]

        public async Task<ActionResult> GetLibraryItemsByBook([FromQuery] Guid bookId)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByBookQuery { Id = bookId }));
        }

        //[AllowAnonymous ]
        [Authorize(Roles = "User, Admin, Moderator")]
        [HttpGet("GetLibraryItemsByUser")]

        public async Task<ActionResult> GetLibraryItemsByUser([FromQuery] Guid userId)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByUserQuery { Id = userId }));
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet("GetLibraryItemsByStatus")]
        public async Task<ActionResult> GetLibraryItemsByStatus([FromQuery] ReadingStatus readingStatus)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByStatusQuery { Status = (readingStatus)}));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateLibraryItem")]
        public async Task<ActionResult> UpdateBook([FromQuery] Guid id, UpdateLibraryItemCommand command)
        {
            if (id != command.LibraryItemId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        //[AllowAnonymous]
        [Authorize(Roles = "User, Admin, Moderator")]
        [HttpPut("UpdateReadingStatusByUser")]
        public async Task<IActionResult> UpdateReadingStatus([FromBody]UpdateReadingStatusByUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("CreateLibraryItem")]
        public async Task<ActionResult<Guid>> CreateLibraryItem(CreateLibraryItemCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin, User, Moderator")]
        [HttpPost("AddLibraryItemByUser")]
        public async Task<ActionResult<Guid>> AddLibraryItemByUser (AddLibraryItemByUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteLibraryItem")]
        public async Task<ActionResult<Guid>> DeleteLibraryItem(Guid id)
        {
            var result = await Mediator.Send(new DeleteLibraryItemCommand { LibraryItemId = id });
            return Ok(result);
        }

        //[AllowAnonymous]
        [Authorize(Roles = "User, Admin, Moderator")]
        [HttpDelete("DeleteLibraryItemByUser")]
        public async Task<ActionResult<Guid>> DeleteLibraryItemByUser(Guid id)
        {
            var result = await Mediator.Send(new DeleteLibraryItemCommand { LibraryItemId = id });
            return Ok(result);
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin, Moderator, User")]
        [HttpGet("GetLibraryItemsByUserAndStatus")]
        public async Task<ActionResult> GetLibraryItemsByUserAndStatus([FromQuery] Guid userId, [FromQuery] ReadingStatus readingStatus)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByUserAndStatusQuery { UserId = userId, ReadingStatus = readingStatus }));
        }
    }
}
