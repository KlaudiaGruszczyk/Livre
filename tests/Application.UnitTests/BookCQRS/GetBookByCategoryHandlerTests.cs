using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BooksCQRS.Queries.GetBookByCategory;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Moq;
using Xunit;

namespace Application.UnitTests
{
    public class GetBookByCategoryHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IMapper> _mockMapper;

        public GetBookByCategoryHandlerTests()
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
                new Book { BookId = new Guid(), Title = "Title 1", Category = "Science Fiction" },
                new Book { BookId = new Guid(), Title = "Title 2", Category = "Science Fiction" },
                new Book { BookId = new Guid(), Title = "Title 3", Category = "Drama" }
            };

            var dtoBooks = new List<GetBookByCategoryDTO>
            {
                new GetBookByCategoryDTO { Title = "Title 1" },
                new GetBookByCategoryDTO { Title = "Title 2" }
            };

            _mockBookRepository
            .Setup(x => x.GetBookByCategory<Book>(It.IsAny<string>()))
            .Returns(books.Where(b => b.Category == "Science Fiction").ToList());

            _mockMapper
                .Setup(x => x.Map<List<GetBookByCategoryDTO>>(It.IsAny<List<Book>>()))
                .Returns(dtoBooks);

            var handler = new GetBookByCategoryHandler(_mockDbContext.Object, _mockBookRepository.Object, _mockMapper.Object);
            var request = new GetBookByCategoryQuery { Category = "Science Fiction" };

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(dtoBooks, result);
        }
    }
}