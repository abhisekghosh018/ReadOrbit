using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public Task<Author> CreateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAllAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByIdAsync(string authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
