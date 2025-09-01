namespace ReadOrbit.APPLICATION.DTOs.ReviewsDTOs
{
    public class UpdateReviewDTO
    {
        public string ReviewId { get; set; }       
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public bool Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
