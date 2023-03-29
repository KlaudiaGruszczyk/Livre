using Application.AuthorsCQRS.Commands.CreateAuthor;
using Application.AuthorsCQRS.Queries.GetAllAuthors;
using Application.AuthorsCQRS.Queries.GetAuthorById;
using Application.AuthorsCQRS.Queries.GetAuthorByName;
using Application.BooksCQRS.Commands.CreateBook;
using Application.BooksCQRS.Queries.GetAllBooks;
using Application.BooksCQRS.Queries.GetBookById;
using Application.BooksCQRS.Queries.GetBookByKeyWord;
using Application.LibraryCQRS.Queries.GetLibraryItemsByStatus;
using Application.LibraryCQRS.Queries.GetLibraryItemsByUser;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Persistence
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {

            CreateMap<Book, GetAllBooksDTO>()
                .ForMember(x => x.Title, y=>y.MapFrom(z=>z.Title))
                .ForMember(x=> x.Author, y => y.MapFrom(z => z.Author.Name));

            CreateMap<GetAllBooksDTO, Book>();

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

            var readingStatus = new ReadingStatus();

            CreateMap<Library, GetLibraryItemsByStatusDTO>()
                .ForMember(m=>m.ReadingStatus, c=> c.MapFrom(s=> readingStatus));
            CreateMap<GetLibraryItemsByStatusDTO, Library>();


            CreateMap<Library, GetLibraryItemsByUserDTO>();
            CreateMap<GetLibraryItemsByUserDTO, Library>();


        }
    }
}
