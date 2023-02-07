using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Domain.Entities;
using System.Reflection;
using MediatR;
using Application.Common.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, IMediator mediator) 
            : base(options)
        {
            _mediator= mediator;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserLibrary> UsersLibraryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Book>()
             .Property(x => x.BookId)
             .IsRequired().ValueGeneratedNever();

            builder.Entity<UserLibrary>()
                .Property(x => x.LibraryItemId)
                .IsRequired().ValueGeneratedNever();

            builder.Entity<User>()  
                .Property(x=>x.UserId)
                .IsRequired().ValueGeneratedNever();

               
            builder.Entity<Author>()
                .Property(x => x.AuthorId)
                .IsRequired().ValueGeneratedNever();


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
