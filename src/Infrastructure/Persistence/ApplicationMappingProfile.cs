using AutoMapper;
using Application.Book.Handlers;
using Domain.Entities;
using Application.Book.Queries.GetAllBooks;
using Application.Book.Commands.CreateBook;

namespace Infrastructure.Persistence
{
    public class ApplicationMappingProfile :Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Book, GetAllBooksDTO>()
                .ForMember(m => m.Author, c => c.MapFrom(s => s.AuthorName));

            CreateMap<Book, GetAllBooksDTO>();

            CreateMap<GetAllBooksDTO, Book>();

            CreateMap<GetAllBooksDTO, Book>()
             .ForMember(m=>m.AuthorName,c=>c.MapFrom(s=>s.Author));

            CreateMap<Book, CreateBookCommand>();
            CreateMap<CreateBookCommand, Book>();



        }
    }
}
