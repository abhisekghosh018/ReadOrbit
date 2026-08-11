using ReadOrbit.APPLICATION.DTOs.BookDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.APPLICATION.Utility;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Result<IEnumerable<GetBookDTO>>> GetAllBooksAsync(int pageNumber = 0, int pageSize = 0)
        {
            int totalCount = await _bookRepository.TotalBookCount();
            var books = await _bookRepository.GetBooksAsync(pageNumber, pageSize);

            if (books == null || !books.Any())
            {
                // return an empty list (or use Fail with a message if you prefer)
                return Result<IEnumerable<GetBookDTO>>.Ok(new List<GetBookDTO>(), totalCount: totalCount);
            }

            var data = books.Select(book => new GetBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Genre = book.Genre.Name,
                PublishedYear = book.PublishedYear,
                ImageUrl = book.ImageUrl
                // if you want TotalCount inside DTO, set it here: TotalCount = totalCount
            }).ToList();

            return Result<IEnumerable<GetBookDTO>>.Ok(data, totalCount: totalCount);
        }
        public async Task<GetBookDTO> GetBookByIdAsync(string id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null) return null;

            return new GetBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Genre = book.Genre.Name,
                PublishedYear = book.PublishedYear
            };

        }
        public async Task<List<GetBookDTO>> GetBooksByTitleOrAuthor(string? title, string? author)
        {
            var books = await _bookRepository.GetBooksByTitleOrAuthor(title, author);

            if (books == null || !books.Any())
                return new List<GetBookDTO>(); // return empty list, not null (best practice)

            var result = books.Select(b => new GetBookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author.Name,
                Genre = b.Genre.Name,
                PublishedYear = b.PublishedYear,
                ImageUrl = b.ImageUrl
            }).ToList();

            return result;
        }


        public async Task<int> AddBookAsync(CreateBookDTO createBookDTO)
        {

            if ((createBookDTO) == null)
            {
                return 0;
            }

            Book book = new Book
            {
                Id = createBookDTO.Id,
                Title = createBookDTO.Title,
                PublishedYear = createBookDTO.PublishedYear,
                AuthorId = createBookDTO.AuthorId,
                GenreId = createBookDTO.GenreId
            };

            return await _bookRepository.AddNewBookAsync(book);
        }
        public async Task<int> UpdateBookAsync(UpdateBookDTO updateBookDTO)
        {
            if (updateBookDTO.Id == null) return 0;

            var existingBook = await _bookRepository.GetBookByIdAsync(updateBookDTO.Id);
            if (existingBook == null) return 0;

            if (!string.IsNullOrEmpty(updateBookDTO.Title))
                existingBook.Title = updateBookDTO.Title;

            if (updateBookDTO.PublishedYear.HasValue)
                existingBook.PublishedYear = updateBookDTO.PublishedYear.Value;

            if (string.IsNullOrEmpty(updateBookDTO.AuthorId))
                existingBook.AuthorId = updateBookDTO.AuthorId;

            if (updateBookDTO.GenreId.HasValue)
                existingBook.GenreId = updateBookDTO.GenreId.Value;

            var updatedbook = await _bookRepository.UpdateBookAsync(existingBook);
            return updatedbook;
        }

    }
}
