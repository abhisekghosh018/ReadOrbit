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

        public async Task<int> CreateReaderGroupAsync(ReaderGroup ReaderGroup)
        {
            _context.Add(ReaderGroup);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReaderGroup>> GetAllReaderGroupsAsync()
        {
          var readerGroups = await _context.ReaderGroups
                .AsNoTracking()
                .Include(rg => rg.Reader)
                .Include(rg => rg.Group)
                .ToListAsync();

            return readerGroups;
        }

        public async Task<ReaderGroup?> GetReaderGroupByIdAsync(string ReaderGroupId)
        {
            var readerGroups = await _context.ReaderGroups
                .AsNoTracking()
                .Include(rg => rg.Reader)
                .Include(rg => rg.Group)
                .FirstOrDefaultAsync(gr=> gr.Id == ReaderGroupId);

            return readerGroups;
        }

        public async Task<int> UpdateReaderGroupAsync(ReaderGroup ReaderGroup)
        {
            _context.Update(ReaderGroup);
            return await _context.SaveChangesAsync();
        }
    }
}
