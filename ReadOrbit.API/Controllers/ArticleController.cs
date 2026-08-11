using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs.ArticleDTOs;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        [Route("createarticle")]
        public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Article not created");
            }
            var result = await _articleService.CreateArticle(createArticleDto);

            return Ok(result);
        }
    }
}
