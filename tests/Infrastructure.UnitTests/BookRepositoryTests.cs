using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetBookById;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infrastructure.Repositories.Tests
{


    public class BookRepositoryTests
    {
        private readonly BookRepository _repository;

        [Fact]
        public async void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var mockDbContext = new Mock<IApplicationDbContext>();
            var mockMapper = new Mock<IMapper>();
            var bookRepository = new BookRepository(mockMapper.Object, mockDbContext.Object);

            var books = new List<Book>
            {
                new Book { Title = "Book 1", AuthorName = "Author 1" },
                new Book { Title = "Book 2", AuthorName = "Author 2" },
                new Book { Title = "Book 3", AuthorName = "Author 3" },
            };

            mockDbContext.Setup(x => x.Books)
                .ReturnsDbSet(books);

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetAllBooks<GetAllBooksDTO>()).Returns(Task.FromResult(new List<GetAllBooksDTO>
            {
                new GetAllBooksDTO { Title = "Book 1", Author = "Author 1" },
                new GetAllBooksDTO { Title = "Book 2", Author = "Author 2" },
                new GetAllBooksDTO { Title = "Book 3", Author = "Author 3" },
            }));
            // Act
            var result = await bookRepository.GetAllBooks<GetAllBooksDTO>();

            // Assert
            Assert.Equal(books.Count, result.Count());
            Assert.Equal(books, result);
        }

        [Fact]
        public void GetBookById_ReturnsBookWithMatchingId()
        {
            // Arrange
            var mockDbContext = new Mock<IApplicationDbContext>();
            var mockMapper = new Mock<IMapper>();
            var bookRepository = new BookRepository(mockMapper.Object, mockDbContext.Object);

            var books = new List<Book>
            {
                new Book { Title = "Book 1", AuthorName = "Author 1", BookId = 1 },
                new Book { Title = "Book 2", AuthorName = "Author 2", BookId = 2 },
                new Book { Title = "Book 3", AuthorName = "Author 3", BookId = 3 },
            };

            mockDbContext.Setup(x => x.Books)
                .ReturnsDbSet(books);

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetBookById<GetBookByIdDTO>()).Returns(Task.FromResult(new List<GetBookByIdDTO>
            {
                new GetBookByIdDTO { Title = "Book 1", AuthorName = "Author 1", BookId = 1 },
                new GetBookByIdDTO { Title = "Book 2", AuthorName = "Author 2", BookId = 2 },
                new GetBookByIdDTO { Title = "Book 3", AuthorName = "Author 3", BookId = 3 },
            }));

            // Act
            var result = bookRepository.GetBookById<GetBookByIdDTO>(2);

            // Assert
            Assert.Equal(books[1], result);
        }
    }
    }