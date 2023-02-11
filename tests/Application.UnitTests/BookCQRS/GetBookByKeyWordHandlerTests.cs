using Application.BooksCQRS.Queries.GetBookByKeyWord;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Application.UnitTests.BookCQRS
{
    public class GetBookByKeyWordHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetBookByKeyWordHandler _handler;
        private readonly GetBookByKeyWordQuery _query;
        private readonly List<GetBookByKeyWordDTO> _books;

        public GetBookByKeyWordHandlerTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetBookByKeyWordHandler(_dbContextMock.Object, _bookRepositoryMock.Object, _mapperMock.Object);
            _query = new GetBookByKeyWordQuery { KeyWord = "Book" };
            _books = new List<GetBookByKeyWordDTO>
            {
                new GetBookByKeyWordDTO { Title = "Book 1", AuthorName = "Author 1" },
                new GetBookByKeyWordDTO { Title = "Book 2", AuthorName = "Author 2" }
            };
        }

        [Fact]
        public async Task Handle_Should_Return_Correct_Result()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.GetBookByKeyWord<GetBookByKeyWordDTO>("Book"))
                .Returns(await Task.FromResult(_books));
            _mapperMock
                .Setup(m => m.Map<List<GetBookByKeyWordDTO>>(_books))
                .Returns(_books);

            // Act
            var result = await _handler.Handle(_query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(_books);
        }
    }

}
