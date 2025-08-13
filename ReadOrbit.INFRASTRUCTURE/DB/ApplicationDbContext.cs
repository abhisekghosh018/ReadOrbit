using Microsoft.EntityFrameworkCore;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.INFRASTRUCTURE.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReader> BookReaders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> ReaderGroups { get; set; }
        public DbSet<ReaderProfile> ReaderProfiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
               
    }
}
