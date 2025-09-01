using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IReviewRepository
    {
        Task<int> CreateReviewAsync(Review review);
        Task<int> UpdateReviewAsync(Review review);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        //Task<ReaderGroup?> GetReviewByIdAsync(string reviewId);
        Task<IEnumerable<Review>> GetReviewByBookIdAsync(string bookId);
        Task<IEnumerable<Review>> GetReviewByBookReaderIdAsync(string bookReaderId);
    }
}
