using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAuthorAsync(Author author)
        {
            _context.Add(author);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<Author>> GetAllAuthorAsync()
        {
            var result = await _context.Authors.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Author?> GetAuthorByIdAsync(string authorId)
        {
            return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == authorId);
        }

        public async Task<int> UpdateAuthorAsync(Author author)
        {
            _context.Update(author);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
