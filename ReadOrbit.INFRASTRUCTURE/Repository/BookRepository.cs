using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBookAsync(Book book)
        {
            _context.Add(book);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Book?> GetBookByIdAsync(string bookId)
        {
            var book = await _context.Books.AsNoTracking()   
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
           var books = await _context.Books.AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre).ToListAsync();

            return books;
        }
    }
}
