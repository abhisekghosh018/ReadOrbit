using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns> Reviews </returns>
        public async Task<IEnumerable<Review>> GetReviewByBookIdAsync(string bookId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(b => b.Book)
                .Where(b => b.BookId == bookId)
                .Include(b => b.Reader)
                .ToListAsync();
            return review;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookReaderId"></param>
        /// <returns> Reviews </returns>
        public async Task<IEnumerable<Review>> GetReviewByBookReaderIdAsync(string bookReaderId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(b => b.Reader)
                .Where(b => b.BookReaderId == bookReaderId)
                .Include(b => b.Book)
                .ToListAsync();
            return review;
        }

        public async Task<int> UpdateReviewAsync(Review review)
        {
            _context.Update(review);
            return await _context.SaveChangesAsync();
        }

    }
}
