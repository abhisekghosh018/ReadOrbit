using ReadOrbit.APPLICATION.DTOs.AthorDTOs;
using ReadOrbit.APPLICATION.DTOs.BookDTOs;
using ReadOrbit.APPLICATION.DTOs.GenreDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        #region GET SERVICES
        public async Task<List<GetAuthorDtos>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAuthorAsync();
            if (!authors.Any())
            {
                return new List<GetAuthorDtos>();
            }
            var authorsDto = authors.Select(author => new GetAuthorDtos
            {
                Id = author.Id,
                Name = author.Name,
                Country = author.Country,
                DOB = author.DOB,
            }).ToList();

            return authorsDto;

        }
        public async Task<GetAuthorDtos> GetAuthorAsync(string id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return null ;
            }
            
            var authorDto = new GetAuthorDtos
            {
                Id = author.Id,
                Name = author.Name,
                Country = author.Country,
                DOB = author.DOB,
            };

            return authorDto;

        }

        public async Task<List<GetAuthorWithBooks>> GetAuthorsWithBooksAsync(string authorId)
        {
            var authors = await _authorRepository.GetAuthorWithBooksAsync(authorId);
            if (!authors.Any())
            {
                return new List<GetAuthorWithBooks>();
            }
            var authorsDto = authors.Select(author => new GetAuthorWithBooks
            {
                Id = author.Id,
                Name = author.Name,
                Country = author.Country,
                DOB = author.DOB,
                Books = author.Books.Select(book => new GetBookDTOForAuthor
                {
                    Title = book.Title,
                    PublishedYear = book.PublishedYear,
                    Genre = new GetGenreDtoForAuthor
                    {
                       Name = book.Genre.Name
                    },
                Reviews = book.Reviews.Select(Review => new BookReviewsForAuthor
                    {
                        Rating = Review.Rating,
                        Comment = Review.Comment
                    }).ToList()
                }).ToList()
            }).ToList();

            return authorsDto;
        }
        #endregion

        #region POST SERVICES
        public async Task<int> CreateAuthorAsync(CreateAuthorDtos createAuthorDtos)
        {
            if (createAuthorDtos == null)
            {
                return 0;
            }
            var author = new Author
            {
                Name = createAuthorDtos.Name,
                Country = createAuthorDtos.Country,
                DOB = createAuthorDtos.DOB,
            };
            return await _authorRepository.CreateAuthorAsync(author);
        }
        #endregion

        #region PUT SERVICES
        public async Task<int> UpdateAuthorAsync(UpdateAuthorDtos UpdateAuthorDtos)
        {
            if (UpdateAuthorDtos == null)
            {
                return 0;
            }

            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(UpdateAuthorDtos.Id);

            if(existingAuthor == null)
            {
                return 0; 
            }

            var author = new Author
            {
                Name = UpdateAuthorDtos.Name,
                Country = UpdateAuthorDtos.Country,
                DOB = UpdateAuthorDtos.DOB,
            };
            return await _authorRepository.UpdateAuthorAsync(author);
        }
        #endregion

    }
}
