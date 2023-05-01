using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using System.Reflection.Emit;

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
        public DbSet<Library> UsersLibraryItems { get; set; }
        public DbSet<ActivationLink> ActivationLinks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
             .HasKey(b => b.BookId);

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(k => k.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Library>()
                .HasKey(b => b.LibraryItemId);

            builder.Entity<Library>()
                .HasOne(l => l.User)
                .WithMany(u => u.UserLibrary)
                .HasForeignKey(l => l.UserId);

            builder.Entity<Library>()
                .HasOne(l => l.Book)
                .WithMany(b => b.UserLibrary)
                .HasForeignKey(l => l.BookId);

            builder.Entity<User>()
                .HasKey(u => u.UserId);

            builder.Entity<User>()
                .HasMany(u => u.UserLibrary)
                .WithOne(li => li.User)
                .HasForeignKey(li => li.UserId);



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
