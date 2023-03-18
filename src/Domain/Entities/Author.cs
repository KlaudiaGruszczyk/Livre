﻿namespace Domain.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
