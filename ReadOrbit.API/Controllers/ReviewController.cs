using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        //private readonly ILogger<ReviewController> _logger;
        private readonly ReviewService reviewService;    
        public ReviewController(ReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("BookReviews/{bookId}")]
        public async Task<IActionResult> GetReviewsByBookId(string bookId)
        {
            var reviews = await reviewService.GetReviewsByBookIdAsync(bookId);
            if (reviews == null)
            {
                return NotFound(new { Message = "No reviews found for the specified book." });
            }
            return Ok(reviews);
        }
    }
}
