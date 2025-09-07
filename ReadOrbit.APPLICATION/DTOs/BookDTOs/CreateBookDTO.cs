using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.BookDTOs
{
    public class CreateBookDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Title is required")]       
        public string Title { get; set; }
        public int PublishedYear { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string AuthorId { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }      
        public string? ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public bool IsApproved { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
