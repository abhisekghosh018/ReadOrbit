using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> GetByIdAsync(Guid id);
        Task<int> CreateArticleAsync(Article article);
        Task<int> UpdateArticleAsync(Article article);
        Task<IEnumerable<Article>> GetAllArticlesAsync();
    }
}
