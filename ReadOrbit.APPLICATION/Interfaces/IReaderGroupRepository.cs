using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IReaderGroupRepository
    {
        Task<int> CreateReaderGroupAsync(ReaderGroup ReaderGroup);
        Task<int> UpdateReaderGroupAsync(ReaderGroup ReaderGroup);
        Task<IEnumerable<ReaderGroup>> GetAllReaderGroupsAsync();
        Task<ReaderGroup?> GetReaderGroupByIdAsync(string ReaderGroupId);
    }
}
