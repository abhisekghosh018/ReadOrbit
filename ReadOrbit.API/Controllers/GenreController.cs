using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs;
using ReadOrbit.APPLICATION.DTOs.GenreDTOs;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;

        public GenreController (GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("getGenres")]
        public async Task<IActionResult> GetGenres()
        {
            var listAuthor = await _genreService.GetGenresAsync();

            if (listAuthor.Count == 0)
            {
                return NoContent();
            }

            return Ok(listAuthor);
        }

        [HttpGet("getGenre/{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var author = await _genreService.GetGenreByIdAsync(id);

            if (author == null)
            {
                return NoContent();
            }

            return Ok(author);
        }

        [HttpPost("createGenre")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto createDto)
        {
            var author = await _genreService.CreateGenreAsync(createDto);

            if (author == 0)
            {
                return NoContent();
            }

            return Ok(author);
        }

        [HttpPost("updateGenre")]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreDto updateDto)
        {
            var author = await _genreService.UpdateGenreAsync(updateDto);

            if (author == 0)
            {
                return NoContent();
            }
            return Ok(author);
        }
    }
}
