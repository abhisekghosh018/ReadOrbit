using ReadOrbit.APPLICATION.DTOs.BookDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }
        public async Task<IEnumerable<GetBookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();

            if (books == null || !books.Any())
            {
                return null;
            }

            return books.Select(book => new GetBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Genre = book.Genre.Name,
                PublishedYear = book.PublishedYear
            }).ToList();
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
            if (updateBookDTO.Id == null) return false;

            var existingBook = await _bookRepository.GetBookByIdAsync(updateBookDTO.Id);
            if (existingBook == null) return false;

            if (!string.IsNullOrEmpty(updateBookDTO.Title))
                existingBook.Title = updateBookDTO.Title;

            if (updateBookDTO.PublishedYear.HasValue)
                existingBook.PublishedYear = updateBookDTO.PublishedYear.Value;

            if (string.IsNullOrEmpty(updateBookDTO.AuthorId))
                existingBook.AuthorId = updateBookDTO.AuthorId;

            if (updateBookDTO.GenreId.HasValue)
                existingBook.GenreId = updateBookDTO.GenreId.Value;

            await _bookRepository.UpdateBookAsync(existingBook);
            return true;
        }


    }
}
