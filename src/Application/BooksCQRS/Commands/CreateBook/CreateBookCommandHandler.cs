using Application.AuthorsCQRS.Commands.CreateAuthor;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BooksCQRS.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMediator _mediator;
        public CreateBookCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {

                try
                {
                    var existingAuthor = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Name == command.AuthorName);

                    Guid authorId;

                    if (existingAuthor != null)
                    {
                        authorId = existingAuthor.AuthorId;
                    }
                    else
                    {
                        var createAuthorCommand = new CreateAuthorCommandHandler(_dbContext);
                        authorId = (Guid)await _mediator.Send(createAuthorCommand);
                    }

                    var book = new Book
                    {
                        BookId = new Guid(),
                        Title = command.Title,
                        Description = command.Description,
                        PublishedDate = command.PublishedDate,
                        Category = command.Category,
                        Publisher = command.Publisher,
                        AuthorId = authorId
                    };

                    _dbContext.Books.AddAsync(book);
                    await _dbContext.SaveChangesAsync();
                    return (Guid)book.BookId;
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;

                }
            }
        }
    }
}



