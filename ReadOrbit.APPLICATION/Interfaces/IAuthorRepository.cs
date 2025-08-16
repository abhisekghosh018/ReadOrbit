using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IAuthorRepository
    {
        Task<int> CreateAuthorAsync(Author author);
        Task<int> UpdateAuthorAsync(Author author);
        Task<IEnumerable<Author>> GetAllAuthorAsync();
        Task<Author?> GetAuthorByIdAsync(string authorId);
        Task<IEnumerable<Author>> GetAuthorWithBooksAsync(string authorId);
    }
}
