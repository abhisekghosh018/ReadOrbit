using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs.AthorDTOs;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("getAuthors")]
        public async Task<IActionResult> GetAuthors() 
        {
            var listAuthor = await _authorService.GetAuthorsAsync();

            if (listAuthor.Count == 0) 
            { 
                return NoContent();
            }

            return Ok(listAuthor);
        }

        [HttpGet("getAuthor/{id}")]
        public async Task<IActionResult> GetAuthor(string id)
        {
            var author = await _authorService.GetAuthorAsync(id);

            if (author == null)
            {
                return NoContent();
            }

            return Ok(author);
        }

        [HttpGet("getAuthorWithBooks/{id}")]
        public async Task<IActionResult> GetAuthorWithBooks(string id)
        {
            var author = await _authorService.GetAuthorsWithBooksAsync(id);
            if (author == null)
            {
                return NoContent();
            }
            return Ok(author);
        }

        [HttpPost("createAuthor")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDtos createDto)
        {
            var author = await _authorService.CreateAuthorAsync(createDto);

            if (author == 0)
            {
                return NoContent();
            }

            return Ok(author);
        }

        [HttpPost("updateAuthor")]
        public async Task<IActionResult> updateAuthor([FromBody] UpdateAuthorDtos updateDto)
        {
            var author = await _authorService.UpdateAuthorAsync(updateDto);

            if (author == 0)
            {
                return NoContent();
            }
            return Ok(author);
        }
    }
}
