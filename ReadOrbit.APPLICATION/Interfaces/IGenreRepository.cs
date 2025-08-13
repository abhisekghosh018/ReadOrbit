using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IGenreRepository
    {
        Task<Book?> GetGenreByIdAsync(string bookId);
        Task<IEnumerable<Book>> GetGenresAsync();
        Task<int> AddNewGenreAsync(Book book);
        Task<int> UpdateGenreAsync(Book book);
    }
}
