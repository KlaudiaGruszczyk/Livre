using AutoMapper;
using Application.Book.Handlers;
using Domain.Entities;
using Application.Book.Queries.GetAllBooks;

namespace Infrastructure.Persistence
{
    public class ApplicationMappingProfile :Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Author, GetAllBooksDTO>()
                .ForMember(m=> m.Author, c=>c.MapFrom(s => s.Name));
            CreateMap<Book, GetAllBooksDTO>();
        }
    }
}
