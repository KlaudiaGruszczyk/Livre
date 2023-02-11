using Application.BooksCQRS.Queries.GetBookByAuthor;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.BookCQRS
{
    public class GetBookByAuthorHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IMapper> _mockMapper;

        public GetBookByAuthorHandlerTests()
        {
            _mockDbContext = new Mock<IApplicationDbContext>();
            _mockBookRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_ReturnsCorrectData()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { BookId = 1, Title = "Title 1", AuthorName = "Author 1" },
                new Book { BookId = 2, Title = "Title 2", AuthorName = "Author 2" },
                new Book { BookId = 3, Title = "Title 3", AuthorName = "Author 1" }
            };

            var dtoBooks = new List<GetBookByAuthorDTO>
            {
                new GetBookByAuthorDTO { Title = "Title 1" },
                new GetBookByAuthorDTO { Title = "Title 3" }
            };

            _mockBookRepository
                .Setup(x => x.GetBookByAuthor<Book>(It.IsAny<string>()))
                .Returns(books.Where(b => b.AuthorName == "Author 1").ToList());

            _mockMapper
                .Setup(x => x.Map<List<GetBookByAuthorDTO>>(It.IsAny<List<Book>>()))
                .Returns(dtoBooks);

            var handler = new GetBookByAuthorHandler(_mockDbContext.Object, _mockBookRepository.Object, _mockMapper.Object);
            var request = new GetBookByAuthorQuery { Name = "Author 1" };

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(dtoBooks, result);
        }
    }
}