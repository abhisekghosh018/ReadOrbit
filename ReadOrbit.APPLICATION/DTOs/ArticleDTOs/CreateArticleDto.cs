using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.ArticleDTOs
{
    public class CreateArticleDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public object ArticleText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PublishedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsPublished { get; set; }
        [Required]
        public string AuthorId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
