using Microsoft.EntityFrameworkCore;
using ReadOrbit.DOMAIN.DomainEntities;
using System.Text.Json;

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
        public DbSet<ReaderGroup> ReaderGroups { get; set; }
        public DbSet<ReaderProfile> ReaderProfiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(a => a.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Article>()
                .Property(a => a.ArticleText)
                .HasColumnType("jsonb")
                .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<object>(v, (JsonSerializerOptions)null)
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
