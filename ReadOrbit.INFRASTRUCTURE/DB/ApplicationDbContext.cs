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
        public DbSet<ol_works> ol_works { get; set; }


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

            modelBuilder.Entity<ol_works>(entity =>
            {
                entity.ToTable("ol_works", "public");
                entity.HasKey(x => x.OlKey);

                //entity.Property(x => x.TotalCount)
                //    .HasColumnName("total_count");

                entity.Property(x => x.OlKey)
                    .HasColumnName("ol_key");

                entity.Property(x => x.Revision)
                    .HasColumnName("revision");

                entity.Property(x => x.LastModified)
                    .HasColumnName("last_modified");

                entity.Property(x => x.Title)
                    .HasColumnName("title");

                entity.Property(x => x.Subtitle)
                    .HasColumnName("subtitle");

                entity.Property(x => x.Description)
                    .HasColumnName("description");

                entity.Property(x => x.FirstPublishDate)
                    .HasColumnName("first_publish_date");

                entity.Property(x => x.Covers)
                    .HasColumnName("covers");

                entity.Property(x => x.Subjects)
                    .HasColumnName("subjects");

                entity.Property(x => x.AuthorKeys)
                    .HasColumnName("author_keys");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
