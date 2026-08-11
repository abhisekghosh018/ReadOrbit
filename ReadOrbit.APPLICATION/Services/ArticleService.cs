using ReadOrbit.APPLICATION.DTOs.ArticleDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<int> CreateArticle(CreateArticleDto createArticleDto)
        {
            if (createArticleDto == null)
            {
                return 0;
            }
            Article article = new Article
            {
                Title = createArticleDto.Title,
                ArticleText = createArticleDto.ArticleText,
                ImageUrl = createArticleDto.ImageUrl,
                IsPublished = createArticleDto.IsPublished,
                PublishedAt = DateTime.UtcNow,
            };
            return await _articleRepository.CreateArticleAsync(article);
        }
    }
}
