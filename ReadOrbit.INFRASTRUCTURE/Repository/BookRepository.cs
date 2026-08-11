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
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            return await _context.SaveChangesAsync();
        }
        public async Task<Book?> GetBookByIdAsync(string bookId)
        {
            var book = await _context.Books.AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            return book;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync(int pageNumber = 0, int pageSize = 0)
        {
            var books = await _context.Books.AsNoTracking()
                 .Include(b => b.Author)
                 .Include(b => b.Genre)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();

            return books;
        }

        public async Task<List<Book?>> GetBooksByTitleOrAuthor(string? title, string? authorName)
        {
            var query = _context.Books.AsNoTracking()
                 .Include(b => b.Author)
                 .Include(b => b.Genre)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(b => b.Title == title);
            }
            else
            {
                query = query.Where(b => b.Author.Name.ToLower().Contains(authorName.ToLower()));
            }
            return await query.ToListAsync();
        }

        public async Task<int> TotalBookCount()
        {
            return _context.Books.AsNoTracking().Count();
        }
    }
}
