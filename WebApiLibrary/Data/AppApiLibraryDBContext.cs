using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Model;

namespace WebApiLibrary.Data
{
    public class AppApiLibraryDBContext : DbContext
    {
        public AppApiLibraryDBContext(DbContextOptions<AppApiLibraryDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>().HasKey(sc => new { sc.AuthorId, sc.BookId });

            modelBuilder.Entity<Book>()
                .HasMany(x => x.AuthorBooks)
                .WithOne(y => y.Book)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Author>()
                .HasMany(x => x.AuthorBooks)
                .WithOne(y => y.Author)
                .OnDelete(DeleteBehavior.NoAction);

        }
        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        //public DbSet<AuthorBook> AuthorBooks { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
