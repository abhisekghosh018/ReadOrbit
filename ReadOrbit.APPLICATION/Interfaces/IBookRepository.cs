using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(string bookId);
        Task<IEnumerable<Book>> GetBooksAsync(int pageNumber = 0, int pazeSize = 0);
        Task<int> AddNewBookAsync(Book book);
        Task<int> UpdateBookAsync(Book book);
    }
}
