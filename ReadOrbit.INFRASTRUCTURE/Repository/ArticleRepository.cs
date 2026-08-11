using Microsoft.EntityFrameworkCore;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using ReadOrbit.INFRASTRUCTURE.DB;

namespace ReadOrbit.INFRASTRUCTURE.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateArticleAsync(Article article)
        {
            try
            {
                await _context.Articles.AddAsync(article);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            var articles = await _context.Articles.AsNoTracking().ToListAsync();
            return articles;
        }

        public async Task<Article> GetByIdAsync(Guid id)
        {
            return await _context.Articles.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> UpdateArticleAsync(Article article)
        {
            _context.Articles.Update(article);
            return await _context.SaveChangesAsync();
        }
    }
}
