namespace ReadOrbit.APPLICATION.DTOs.BookDTOs
{
    public class UpdateBookDTO
    {
        public string Id { get; set; } 
        public string? Title { get; set; }
        public int? PublishedYear { get; set; }
        public string AuthorId { get; set; }
        public int? GenreId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
