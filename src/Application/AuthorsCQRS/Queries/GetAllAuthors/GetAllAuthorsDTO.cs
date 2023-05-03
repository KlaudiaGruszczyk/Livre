namespace Application.AuthorsCQRS.Queries.GetAllAuthors
{
    public class GetAllAuthorsDTO
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
    }
}
