using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IBookReaderRepository
    {
        Task<int> CreateBookReaderAsync(BookReader bookReader);
        Task<int> UpdateBookReaderAsync(BookReader bookReader);
        Task<IEnumerable<BookReader>> GetAllBookReadersAsync();
        Task<BookReader?> GetBookReaderByIdAsync(string bookReaderId);
    }
}
