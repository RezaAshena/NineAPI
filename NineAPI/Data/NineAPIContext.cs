using Microsoft.EntityFrameworkCore;
using NineAPI.Models;

namespace NineAPI.Data
{
    public class NineAPIContext : DbContext
    {
        public NineAPIContext(DbContextOptions<NineAPIContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configuration can go here
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", YearPublished = 1949 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Bill  Smith", YearPublished = 1960 },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", YearPublished = 1925 },
                new Book { Id = 4, Title = "Brave New World", Author = "Aldous Huxley", YearPublished = 1932 }
                );

        }
        // Define DbSets for your entities here
        public DbSet<Book> Books { get; set; }
        // public DbSet<Author> Authors { get; set; }
        // Add other DbSets as needed
    }
}
