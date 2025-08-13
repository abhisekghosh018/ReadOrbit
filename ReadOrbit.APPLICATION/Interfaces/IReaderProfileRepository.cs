using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IReaderProfileRepository
    {
        Task<int> CreateReaderProfileAsync(ReaderProfile readerProfile);
        Task<int> UpdateReaderProfileAsync(ReaderProfile author);
        Task<IEnumerable<ReaderProfile>> GetAllReaderProfileAsync();
        Task<ReaderProfile?> GetReaderProfileByIdAsync(string readerProfileId);
    }
}
