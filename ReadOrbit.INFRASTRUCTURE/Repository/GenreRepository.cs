using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewGenreAsync(Genre genre)
        {
            _context.Add(genre);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Genre?> GetGenreByIdAsync(int genreId)
        {
            var book = await _context.Genres.AsNoTracking()              
                      .FirstOrDefaultAsync(b => b.Id == genreId);

            return book;           
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres.AsNoTracking().ToListAsync();
        }

        public async Task<int> UpdateGenreAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            return await _context.SaveChangesAsync();           
        }
        
    }
}
