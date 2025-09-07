using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.ReviewsDTOs
{
    public class CreateReviewDTO
    {
        public Guid ReviewId { get; set; } = Guid.NewGuid();       
        public string BookId { get; set; }      
        public string BookReaderId { get; set; }       
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public bool Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;       
    }
}
