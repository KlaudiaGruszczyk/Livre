using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserLibrary> UsersLibraryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(k => k.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<UserLibrary>()
                .Property(x => x.LibraryItemId)
                .IsRequired().ValueGeneratedNever();

            builder.Entity<User>()
                .Property(x => x.UserId)
                .IsRequired().ValueGeneratedNever();


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
        public async Task<int> SaveChangesAsync()
        {

            return await base.SaveChangesAsync();
        }

        public DatabaseFacade Database => base.Database;
    }
}
