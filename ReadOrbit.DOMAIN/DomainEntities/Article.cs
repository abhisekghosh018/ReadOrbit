using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        public object ArticleText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPublished { get; set; }
        public string ReaderId { get; set; }
        public string AuthorId { get; set; }
        public string ImageUrl { get; set; }
    }
}
