using ReadOrbit.DOMAIN.DomainEntities;

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
