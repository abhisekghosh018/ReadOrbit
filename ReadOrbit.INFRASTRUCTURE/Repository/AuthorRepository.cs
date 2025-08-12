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

        public Task<Author> CreateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAllAuthorAsync()
        {
           var result = await _context.Authors.AsNoTracking().ToListAsync();
           return result;
        }

        public Task<Author> GetAuthorByIdAsync(string authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
