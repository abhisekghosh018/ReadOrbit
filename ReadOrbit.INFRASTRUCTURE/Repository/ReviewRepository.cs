using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;
using System.Net;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateReviewAsync(Review review)
        {
            _context.Add(review);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            
            var reviews= await _context.Reviews
                .AsNoTracking()
                .Include(b=> b.Book)
                .Include(b=> b.Reader)
                .ToListAsync();
            return reviews;

        }

        public async Task<Review?> GetReviewByBookIdAsync(string bookId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(b=> b.BookId == bookId);
            return review;
        }

        public async Task<Review?> GetReviewByBookReaderIdAsync(string bookReaderId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(b => b.BookReaderId == bookReaderId);
            return review;
        }

        public async Task<Review?> GetReviewByIdAsync(string reviewId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(b => b.ReviewId == reviewId);
            return review;
        }

        public async Task<int> UpdateReviewAsync(Review review)
        {
            _context.Update(review);
            return await _context.SaveChangesAsync();
        }
    }
}
