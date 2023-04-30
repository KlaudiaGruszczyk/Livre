using Minio.DataModel;

namespace Infrastructure.Services
{
    public class ListObjectResult
    {
        public List<Item> Items { get; set; } = new List<Item>();
    }
}

