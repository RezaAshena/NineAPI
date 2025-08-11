using Microsoft.EntityFrameworkCore;
using NineAPI.Models;

namespace NineAPI.Data
{
    public class NineAPIContext:DbContext
    {
        public NineAPIContext(DbContextOptions<NineAPIContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configuration can go here
        }
        // Define DbSets for your entities here
         public DbSet<Book> Books { get; set; }
        // public DbSet<Author> Authors { get; set; }
        // Add other DbSets as needed
    }
}
