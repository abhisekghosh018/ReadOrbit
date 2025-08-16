using ReadOrbit.APPLICATION.DTOs.ReaderDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Services
{
    public class ReaderService
    {
        private readonly IBookReaderRepository _bookReaderRepository;
        public ReaderService(IBookReaderRepository bookReaderRepository)
        {
            _bookReaderRepository = bookReaderRepository;
        }
        public async Task<BookReader> GetBookReaderByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("BookReader ID cannot be null or empty", nameof(id));
            }
            var bookReader = await _bookReaderRepository.GetBookReaderByIdAsync(id);
            if (bookReader == null)
            {
                throw new KeyNotFoundException($"BookReader with ID {id} not found");
            }
            return bookReader;
        }   
        public async Task<int> CreateBookReaderAsync(CreateReaderDTO bookReaderDto)
        {
            if (bookReaderDto == null)
            {
                throw new ArgumentNullException(nameof(bookReaderDto), "BookReader cannot be null");
            }

            if (string.IsNullOrWhiteSpace(bookReaderDto.UserName) || string.IsNullOrWhiteSpace(bookReaderDto.Email))
            {
                throw new ArgumentException("BookReader username and email cannot be empty", nameof(bookReaderDto.UserName));
            }

            var reader = new BookReader
            {
                Id  = bookReaderDto.Id,
                UserName = bookReaderDto.UserName,
                Email = bookReaderDto.Email,        
                Mobile = bookReaderDto.Mobile,
                ProfileId = bookReaderDto.ProfileId,
                Status = true,
                IsApproved = true,
                JoinDate = bookReaderDto.JoinDate
            };  

            return await _bookReaderRepository.CreateBookReaderAsync(reader);
        }
        public async Task<int> UpdateBookReaderAsync(CreateReaderDTO bookReaderDto)
        {
            if (bookReaderDto == null)
            {
                throw new ArgumentNullException(nameof(bookReaderDto), "BookReader cannot be null");
            }

            if (string.IsNullOrWhiteSpace(bookReaderDto.UserName) || string.IsNullOrWhiteSpace(bookReaderDto.Email))
            {
                throw new ArgumentException("BookReader username and email cannot be empty", nameof(bookReaderDto.UserName));
            }

            var existingReader = await _bookReaderRepository.GetBookReaderByIdAsync(bookReaderDto.Id);

            if (existingReader == null)
            {
                throw new KeyNotFoundException($"BookReader with ID {bookReaderDto.Id} not found");
            }

            if (!string.IsNullOrWhiteSpace(bookReaderDto.UserName))
                existingReader.UserName = bookReaderDto.UserName;

            if (!string.IsNullOrWhiteSpace(bookReaderDto.Email))
                existingReader.Email = bookReaderDto.Email;

            if (!string.IsNullOrWhiteSpace(bookReaderDto.Mobile))
                existingReader.Mobile = bookReaderDto.Mobile;

            return await _bookReaderRepository.UpdateBookReaderAsync(existingReader);
        }

    }
}
