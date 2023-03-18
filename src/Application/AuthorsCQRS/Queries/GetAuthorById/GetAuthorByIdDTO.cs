using Application.Common.Interfaces;

namespace Application.AuthorsCQRS.Queries.GetAuthorById
{
    public class GetAuthorByIdDTO : IAuthorDetails
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
