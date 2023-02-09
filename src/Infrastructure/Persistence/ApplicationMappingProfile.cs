using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using Application.Authors.Queries.GetAuthorByName;
using Application.Book.Commands.CreateBook;
using Application.Book.Queries.GetAllBooks;
using Application.Book.Queries.GetBookById;
using Application.Book.Queries.GetBookByKeyWord;
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
