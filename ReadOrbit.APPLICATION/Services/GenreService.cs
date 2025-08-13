using ReadOrbit.APPLICATION.DTOs;
using ReadOrbit.APPLICATION.DTOs.GenreDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService (IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        #region GET SERVICES
        public async Task<List<GetGenreDto>> GetGenresAsync()
        {
            var genres = await _genreRepository.GetGenresAsync();
            if (!genres.Any())
            {
                return new List<GetGenreDto>();
            }
            var authorsDto = genres.Select(genre => new GetGenreDto
            {
                Id = genre.Id,
                Name = genre.Name,             
            }).ToList();

            return authorsDto;

        }
        public async Task<GetGenreDto> GetGenreByIdAsync(int id)
        {
            var author = await _genreRepository.GetGenreByIdAsync(id);
            if (author == null)
            {
                return null;
            }

            var genre = new GetGenreDto
            {
                Id = author.Id,
                Name = author.Name,              
            };

            return genre;

        }
        #endregion

        #region POST SERVICES
        public async Task<int> CreateGenreAsync(CreateGenreDto createGenreDto)
        {
            if (createGenreDto == null)
            {
                return 0;
            }
            var genre = new Genre
            {
                Name = createGenreDto.Name,               
            };
            return await _genreRepository.AddNewGenreAsync(genre);
        }
        #endregion

        #region PUT SERVICES
        public async Task<int> UpdateGenreAsync(UpdateGenreDto updateGenreDto)
        {
            if (updateGenreDto == null)
            {
                return 0;
            }

            var existingAuthor = await _genreRepository.GetGenreByIdAsync(updateGenreDto.Id);

            if (existingAuthor == null)
            {
                return 0;
            }

            var genre = new Genre
            {
                Name = updateGenreDto.Name,              
            };
            return await _genreRepository.UpdateGenreAsync(genre);
        }
        #endregion
    }
}
