using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(string bookId);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<int> AddNewBookAsync(Book book);
        Task<int> UpdateBookAsync(Book book);
    }
}
