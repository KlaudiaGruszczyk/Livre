using Application.Common.Interfaces;
using Infrastructure.Repositories;

namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdDTO : IAuthorDetails
    {
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
