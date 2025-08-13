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
        Task<Genre?> GetGenreByIdAsync(int genreId);
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<int> AddNewGenreAsync(Genre genre);
        Task<int> UpdateGenreAsync(Genre genre);
    }
}
