using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Book.Queries.GetAllBooks;
using MediatR;
using Domain.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;

        public BookController(IMediator mediator, IBookRepository bookRepository)
        {
            _mediator= mediator;
            _bookRepository= bookRepository;
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
