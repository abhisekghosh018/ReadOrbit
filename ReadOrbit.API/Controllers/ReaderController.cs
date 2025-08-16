using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs.ReaderDTOs;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly ReaderService _readerService;
        public ReaderController(ReaderService readerService)
        {
            _readerService = readerService;
        }


        [HttpGet("getBookReader/{id}")]
        public async Task<IActionResult> GetBookReaderByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Reader ID cannot be null or empty");
            }

            var bookReader = await _readerService.GetBookReaderByIdAsync(id);

            if (bookReader == null)
            {
                return NotFound($"Reader with ID {id} not found");
            }

            return Ok(bookReader);
        }

        [HttpPost("createReader")]
        public async Task<IActionResult> CreateBookReader([FromBody] CreateReaderDTO bookReaderDto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                var result = await _readerService.CreateBookReaderAsync(bookReaderDto);
                if (result == 0)
                {
                    return NotFound($"Failed");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Unexpected error",
                    Detail = ex.InnerException.Message,
                    Status = 500
                };
                return StatusCode(500, problemDetails);
            }
        }
        [HttpPost("UpdateReader")]
        public async Task<IActionResult> UpdateBookReader([FromBody] CreateReaderDTO bookReaderDto)
        {
            if (string.IsNullOrEmpty(bookReaderDto.Id))
            {
                return BadRequest(ModelState);
            }
            var result = await _readerService.UpdateBookReaderAsync(bookReaderDto);
            if (result == 0)
            {
                return NotFound($"Failed");
            }
            return Ok(result);
        }
    }
}
