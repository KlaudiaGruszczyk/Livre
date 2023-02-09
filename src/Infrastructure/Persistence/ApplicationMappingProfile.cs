using Application.AuthorsCQRS.Commands.CreateAuthor;
using Application.AuthorsCQRS.Queries.GetAllAuthors;
using Application.AuthorsCQRS.Queries.GetAuthorById;
using Application.AuthorsCQRS.Queries.GetAuthorByName;
using Application.BooksCQRS.Commands.CreateBook;
using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetBookById;
using Application.BooksCQRS.Queries.GetBookByKeyWord;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Book, GetAllBooksDTO>()
                .ForMember(m => m.Author, c => c.MapFrom(s => s.AuthorName));

            CreateMap<Book, GetAllBooksDTO>();

            CreateMap<GetAllBooksDTO, Book>();

            CreateMap<GetAllBooksDTO, Book>()
             .ForMember(m => m.AuthorName, c => c.MapFrom(s => s.Author));

            CreateMap<Book, CreateBookCommand>();
            CreateMap<CreateBookCommand, Book>();

            CreateMap<Book, GetBookByIdDTO>();
            CreateMap<GetBookByIdDTO, Book>();

            CreateMap<Book, GetBookByKeyWordDTO>();
            CreateMap<GetBookByKeyWordDTO, Book>();

            CreateMap<Author, GetAllAuthorsDTO>();
            CreateMap<GetAllAuthorsDTO, Author>();

            CreateMap<Author, GetAuthorByIdDTO>();
            CreateMap<GetAuthorByIdDTO, Author>();

            CreateMap<Author, GetAuthorByNameDTO>();
            CreateMap<GetAuthorByNameDTO, Author>();

            CreateMap<Author, CreateAuthorCommand>();
            CreateMap<CreateAuthorCommand, Author>();


        }
    }
}
