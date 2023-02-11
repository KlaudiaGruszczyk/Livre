using Application.BooksCQRS.Queries.GetBookById;
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
using Domain.Entities;

namespace Application.UnitTests.BookCQRS
{
    public class GetBookByIdHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetBookByIdHandler _handler;
        private readonly GetBookByIdQuery _query;
        private readonly GetBookByIdDTO _book;

        public GetBookByIdHandlerTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetBookByIdHandler(_dbContextMock.Object, _bookRepositoryMock.Object, _mapperMock.Object);
            _query = new GetBookByIdQuery { Id = 1 };
            _book = new GetBookByIdDTO { Title = "Book 1", AuthorName = "Author 1" };
        }

        [Fact]
        public async Task Handle_Should_Return_Correct_Result()
        {
            _bookRepositoryMock
                 .Setup(repo => repo.GetBookById<Book>(1))
                 .Returns(await Task.FromResult(new Book { Title = "Book 1", AuthorName = "Author 1" }));
            _mapperMock
                .Setup(m => m.Map<GetBookByIdDTO>(It.IsAny<Book>()))
                .Returns(_book);

            // Act
            var result = await _handler.Handle(_query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(_book);
        }
    }
}