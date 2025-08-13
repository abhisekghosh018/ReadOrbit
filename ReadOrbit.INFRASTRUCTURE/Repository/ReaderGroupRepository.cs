using Microsoft.EntityFrameworkCore;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public class BookRepository : IReaderGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateReaderGroupAsync(Review ReaderGroup)
        {
            _context.Add(ReaderGroup);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetAllReaderGroupsAsync()
        {
          var readerGroups = await _context.ReaderGroups
                .AsNoTracking()
                .Include(rg => rg.Readers)
                .Include(rg => rg.Books)
                .ToListAsync();

            return readerGroups;
        }

        public async Task<Review?> GetReaderGroupByIdAsync(string ReaderGroupId)
        {
            var readerGroups = await _context.ReaderGroups
                .AsNoTracking()
                .Include(rg => rg.Readers)
                .Include(rg => rg.Books)
                .FirstOrDefaultAsync(gr=> gr.ReviewId == ReaderGroupId);

            return readerGroups;
        }

        public async Task<int> UpdateReaderGroupAsync(Review ReaderGroup)
        {
            _context.Update(ReaderGroup);
            return await _context.SaveChangesAsync();
        }
    }
}
