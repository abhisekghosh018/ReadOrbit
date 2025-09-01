namespace ReadOrbit.APPLICATION.DTOs.ReviewsDTOs
{
    public class ReviewDTO
    {
        public Guid ReviewId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class BooksReviewDTO
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public List<ReaderReviewDTO> Readers { get; set; } = new();
        public List<ReviewDTO> Reviews { get; set; } = new();
    }
    public class ReaderReviewDTO
    {
        public string ReaderId { get; set; }
        public string ReaderName { get; set; }
        public List<ReviewDTO> Reviews { get; set; } = new();
    }
}
