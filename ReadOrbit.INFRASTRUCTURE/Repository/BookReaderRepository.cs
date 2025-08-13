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

        public async Task<int> CreateBookReaderAsync(BookReader BookReader)
        {
            _context.Add(BookReader);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookReader>> GetAllBookReadersAsync()
        {
           var bookReaders = await _context.BookReaders
                .AsNoTracking()
                .Include(p=> p.ProfileId)
                .ToListAsync();

            return bookReaders;
        }

        public async Task<BookReader?> GetBookReaderByIdAsync(string BookReaderId)
        {
            var bookReaders = await _context.BookReaders
                .AsNoTracking()
                .Include(p => p.ProfileId)
                .FirstOrDefaultAsync(b => b.Id == BookReaderId);
            return bookReaders;
        }

        public async Task<int> UpdateBookReaderAsync(BookReader BookReader)
        {
            _context.Update(BookReader);
            return await _context.SaveChangesAsync();
        }
    }
}
