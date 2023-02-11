using Application.BooksCQRS.Queries.GetAllBooks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using FluentAssertions;

namespace Application.UnitTests.BookCQRS
{
    public class GetAllBooksHandlerTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly GetAllBooksHandler _handler;
        private readonly GetAllBooksQuery _query;
        private readonly List<Book> _books;
        private readonly IEnumerable<GetAllBooksDTO> _expectedResult;

        public GetAllBooksHandlerTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _mapperMock = new Mock<IMapper>();
            _dbContextMock = new Mock<IApplicationDbContext>();
            _handler = new GetAllBooksHandler(_bookRepositoryMock.Object, _mapperMock.Object, _dbContextMock.Object);
            _query = new GetAllBooksQuery();
            _books = new List<Book>
        {
            new Book { Title = "Book 1", AuthorName = "Author 1" },
            new Book { Title = "Book 2", AuthorName = "Author 2" },
            new Book { Title = "Book 3", AuthorName = "Author 3" }
        };
            _expectedResult = _books.Select(b => new GetAllBooksDTO { Title = b.Title, Author = b.AuthorName });
        }

        [Fact]
        public async Task Handle_Should_Return_Correct_Result()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.GetAllBooks<Book>())
                .Returns(Task.FromResult(_books));
            _mapperMock
                .Setup(m => m.Map<List<GetAllBooksDTO>>(_books))
                .Returns(_expectedResult.ToList());
            // Act
            var result = await _handler.Handle(_query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(_expectedResult);
        }

        [Fact]
        public async Task Handle_Should_Call_GetAllBooks_Method_Once()
        {
            // Arrange
            _bookRepositoryMock
                        .Setup(repo => repo.GetAllBooks<Book>())
                        .Returns(Task.FromResult(_books));
            // Act
            await _handler.Handle(_query, CancellationToken.None);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.GetAllBooks<GetAllBooksDTO>(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Call_Map_Method_Once()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.GetAllBooks<Book>())
                .Returns(Task.FromResult(_books));
            // Act
            await _handler.Handle(_query, CancellationToken.None);

            // Assert
            _mapperMock.Verify(m => m.Map<IEnumerable<GetAllBooksDTO>>(_books), Times.Once);
        }
    }
}

