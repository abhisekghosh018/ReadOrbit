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
        //public async Task<IEnumerable<object>> GetReviewByBookIdAsync(string bookId)
        //{
        //    var reviews = await _context.Reviews
        //        .AsNoTracking()
        //        .Where(r => r.BookId == (bookId)) // filter by BookId
        //        .Include(r => r.Book)   // join Books
        //        .Include(r => r.Reader) // join BookReaders
        //        .Select(r => new
        //        {
        //            r.Id,
        //            r.BookReaderId,
        //            r.Rating,
        //            r.Comment,
        //            r.CreatedAt,
        //            Book = new
        //            {
        //                Book_Id = r.Book.Id,
        //                Book_Title = r.Book.Title,
        //                Book_GenreId = r.Book.GenreId,
        //                Book_AuthorId = r.Book.AuthorId
        //            },
        //            Reader = new
        //            {
        //                Reader_Id = r.Reader.Id,
        //                Reader_Name = r.Reader.UserName
        //            }
        //        })
        //        .ToListAsync();

        //    return reviews;
        //}


        public async Task<IEnumerable<Review>> GetReviewByBookReaderIdAsync(string bookReaderId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .Where(b => b.BookReaderId == bookReaderId)
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
