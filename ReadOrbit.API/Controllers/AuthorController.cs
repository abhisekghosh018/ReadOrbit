using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs;
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
    }
}
