using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs.BookDTOs;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("getBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            if (books == null || !books.Any())
            {
                return NotFound("No books found.");
            }
            return Ok(books);
        }
        [HttpGet("getBook/{id}")]
        public async Task<IActionResult> GetBook(string id)
        {
            var books = await _bookService.GetBookByIdAsync(id);
            if (books == null)
            {
                return NotFound("No books found.");
            }
            return Ok(books);
        }
        [HttpPost("createBook")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO createBookDTO)
        {
            var books = await _bookService.AddBookAsync(createBookDTO);
            if (books == 0)
            {
                return NotFound("Could not create new book");
            }
            return Ok(books);
        }
        [HttpPut("updateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDTO pdateBookDTO)
        {
            var book = await _bookService.UpdateBookAsync(pdateBookDTO);
            if (book == 0)
            {
                return NotFound("Update failed.");
            }
            return Ok(book);
        }
    }
}
