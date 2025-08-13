using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group?> GetGroupByIdAsync(string groupId);
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<int> AddNewGroupAsync(Group group);
        Task<int> UpdateGroupAsync(Group group);
    }
}
