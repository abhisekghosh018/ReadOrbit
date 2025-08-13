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
        Task<int> CreateReaderGroupAsync(Review ReaderGroup);
        Task<int> UpdateReaderGroupAsync(Review ReaderGroup);
        Task<IEnumerable<Review>> GetAllReaderGroupsAsync();
        Task<Review?> GetReaderGroupByIdAsync(string ReaderGroupId);
    }
}
