using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class ReaderProfileRepository : IReaderProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public ReaderProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateReaderProfileAsync(ReaderProfile readerProfile)
        {
            _context.Add(readerProfile);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReaderProfile>> GetAllReaderProfileAsync()
        {
            var readerProfiles = await _context.ReaderProfiles.AsNoTracking().ToListAsync();
            return readerProfiles;
        }

        public async Task<ReaderProfile?> GetReaderProfileByIdAsync(string readerProfileId)
        {
            var readerProfiles = await _context.ReaderProfiles.AsNoTracking()
                                .FirstOrDefaultAsync(rp => rp.Id == readerProfileId);
            return readerProfiles;
        }

        public async Task<int> UpdateReaderProfileAsync(ReaderProfile readerProfile)
        {
            _context.Update(readerProfile);
            return await _context.SaveChangesAsync();
        }
    }
}
