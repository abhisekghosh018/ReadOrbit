using Microsoft.EntityFrameworkCore;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public class BookReaderRepository : IBookReaderRepository
    {

        private readonly ApplicationDbContext _context;

        public BookReaderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Asynchronously creates a new book reader in the database.
        /// </summary>
        /// <param name="BookReader">The <see cref="BookReader"/> instance to be added to the database. Cannot be null.</param>
        /// <returns>The number of state entries written to the database as a result of the operation.</returns>
        public async Task<int> CreateBookReaderAsync(BookReader BookReader)
        {
            _context.Add(BookReader);
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Asynchronously fetch list of book readers from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookReader>> GetAllBookReadersAsync()
        {
           var bookReaders = await _context.BookReaders
                .AsNoTracking()
                .Include(p=> p.Profile)
                .ToListAsync();

            return bookReaders;
        }
        /// <summary>
        /// Asynchronously fetch sing book reader from the database using Id.
        /// </summary>
        /// <param name="BookReaderId"></param>
        /// <returns></returns>
        public async Task<BookReader?> GetBookReaderByIdAsync(string BookReaderId)
        {
            var bookReaders = await _context.BookReaders
                .AsNoTracking()
                .Include(p => p.ProfileId)
                .FirstOrDefaultAsync(b => b.Id == BookReaderId);
            return bookReaders;
        }
        /// <summary>
        /// Asynchronously update a book reader in the database.
        /// </summary>
        /// <param name="BookReader"></param>
        /// <returns>The number of state entries written to the database as a result of the operation.</returns>
        public async Task<int> UpdateBookReaderAsync(BookReader BookReader)
        {
            _context.Update(BookReader);
            return await _context.SaveChangesAsync();
        }
    }
}
