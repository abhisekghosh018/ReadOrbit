using ReadOrbit.APPLICATION.DTOs.ReviewsDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<int> CreateReviewAsync(CreateReviewDTO reviewDto)
        {
            if (reviewDto == null)
            {
                throw new ArgumentNullException(nameof(reviewDto));
            }
            var review = new Review
            {
                BookId = reviewDto.BookId,
                BookReaderId = reviewDto.BookReaderId,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment
            };
            return await _reviewRepository.CreateReviewAsync(review);
        }
        // Service
        public async Task<BooksReviewDTO> GetReviewsByBookIdAsync(string bookId)
        {
            var reviews = await _reviewRepository.GetReviewByBookIdAsync(bookId);

            if (!reviews.Any())
            {
                return new BooksReviewDTO
                {
                    BookId = bookId,
                    Title = "Unknown Title",
                    Readers = new List<ReaderReviewDTO>()
                };
            }

            var book = reviews.First().Book;

            var dto = new BooksReviewDTO
            {
                BookId = book.Id,
                Title = book.Title,
                Readers = reviews
                    .GroupBy(r => r.Reader) // group reviews by reader
                    .Select(g => new ReaderReviewDTO
                    {
                        ReaderId = g.Key.Id,
                        ReaderName = g.Key.UserName,
                        Reviews = g.Select(r => new ReviewDTO
                        {
                            ReviewId = r.Id,
                            Rating = r.Rating,
                            Comment = r.Comment,
                            CreatedAt = r.CreatedAt
                        }).ToList()
                    })
                    .ToList()
            };

            return dto;
        }
      
    }
}
    