using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.BookDTOs
{
    public class UpdateBookDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        public int? PublishedYear { get; set; }
        [Required(ErrorMessage = "uthor is required")]
        public string AuthorId { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public int? GenreId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
