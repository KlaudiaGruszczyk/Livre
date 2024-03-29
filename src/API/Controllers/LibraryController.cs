﻿using Application.BooksCQRS.Commands.CreateBook;
using Application.BooksCQRS.Commands.DeleteBook;
using Application.BooksCQRS.Commands.UpdateBook;
using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetBookById;
using Application.LibraryCQRS.Commands.CreateLibraryItem;
using Application.LibraryCQRS.Commands.DeleteLibraryItem;
using Application.LibraryCQRS.Commands.UpdateLibraryItem;
using Application.LibraryCQRS.Queries.GetAllLibraryItems;
using Application.LibraryCQRS.Queries.GetLibraryItemById;
using Application.LibraryCQRS.Queries.GetLibraryItemsByBook;
using Application.LibraryCQRS.Queries.GetLibraryItemsByStatus;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
using Domain.Enums;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class LibraryController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILibraryRepository _libraryRepository;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet("GetAllLibraryItems")]
        public async Task<ActionResult> GetAllLibraryItems()
        {
            var query = new GetAllLibraryItemsQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetLibraryItemById")]
        public async Task<ActionResult> GetLibraryItemById([FromQuery] int id)
        {
            return Ok(await Mediator.Send(new GetLibraryItemByIdQuery { Id = id }));
        }

        [HttpGet("GetLibraryItemsByBook")]

        public async Task<ActionResult> GetLibraryItemsByBook([FromQuery] int bookId)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByBookQuery { Id = bookId }));
        }

        [HttpGet("GetLibraryItemsByUser")]

        public async Task<ActionResult> GetLibraryItemsByUser([FromQuery] int userId)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByUserQuery { Id = userId }));
        }

        [HttpGet("GetLibraryItemsByStatus")]
        public async Task<ActionResult> GetLibraryItemsByStatus([FromQuery] ReadingStatus readingStatus)
        {
            return Ok(await Mediator.Send(new GetLibraryItemsByStatusQuery { Status = (readingStatus)}));
        }

        [HttpPut("UpdateLibraryItem")]
        public async Task<ActionResult> UpdateBook([FromQuery] int id, UpdateLibraryItemCommand command)
        {
            if (id != command.LibraryItemId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("CreateLibraryItem")]
        public async Task<ActionResult<int>> CreateLibraryItem(CreateLibraryItemCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteLibraryItem")]
        public async Task<ActionResult<int>> DeleteLibraryItem(int id)
        {
            var result = await Mediator.Send(new DeleteLibraryItemCommand { LibraryItemId = id });
            return Ok(result);
        }
    }
}
