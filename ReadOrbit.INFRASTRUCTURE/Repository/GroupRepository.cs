using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewGroupAsync(Group group)
        {
            _context.Add(group);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Group?> GetGroupByIdAsync(string groupId)
        {
            var group = await _context.Groups.AsNoTracking()
                      .FirstOrDefaultAsync(b => b.Id == groupId);

            return group;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _context.Groups.AsNoTracking().ToListAsync();
        }

        public async Task<int> UpdateGroupAsync(Group group)
        {
            _context.Update(group);
            return await _context.SaveChangesAsync();
        }
    }
}
