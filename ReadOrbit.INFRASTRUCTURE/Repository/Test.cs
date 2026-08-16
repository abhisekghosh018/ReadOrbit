using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class Test : ITest
    {
        private readonly ApplicationDbContext _context;
        public Test(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ol_works>> GetAllOlAsync()
        {
            //return await _context.ol_works.Take(100000).AsNoTracking().ToListAsync();

            return await _context.ol_works.AsNoTracking().Select(x => new ol_works
            {

                OlKey = x.OlKey,
                Revision = x.Revision,
                Title = x.Title,
                Subtitle = x.Subtitle,
                Description = x.Description,
                Covers = x.Covers,
                Subjects = x.Subjects,
                AuthorKeys = x.AuthorKeys
            })
            .Take(3000000)
            .ToListAsync();
        }

        public async Task<IEnumerable<ol_works>> GetOlPageFromDbAsync(int pageNumber, int pageSize)
        {
            // Basic math for pagination offset
            int skip = (pageNumber - 1) * pageSize;

            return await _context.ol_works
                .AsNoTracking()
                .Select(x => new ol_works
                {
                    OlKey = x.OlKey,
                    Revision = x.Revision,
                    Title = x.Title,
                    Subtitle = x.Subtitle,
                    Description = x.Description,
                    Covers = x.Covers,
                    Subjects = x.Subjects,
                    AuthorKeys = x.AuthorKeys
                })
                .OrderBy(x => x.OlKey) // Crucial for reliable database pagination
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }



        public async Task<List<ol_works>> GetOlWorksBatchAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            return await _context.ol_works
                .AsNoTracking()
                .OrderBy(x => x.OlKey)
                .Skip(skip)
                .Take(take)
                .Select(x => new ol_works
                {
                    OlKey = x.OlKey,
                    Revision = x.Revision,
                    Title = x.Title,
                    Subtitle = x.Subtitle,
                    Description = x.Description,
                    Covers = x.Covers,
                    Subjects = x.Subjects,
                    AuthorKeys = x.AuthorKeys
                })
                .ToListAsync(cancellationToken);
        }
    }
}

