using ReadOrbit.APPLICATION.DTOs;
using ReadOrbit.APPLICATION.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<List<GetAuthorDtos>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAuthorAsync();
            if (!authors.Any())
            {
                return new List<GetAuthorDtos>();
            }
            var getAuthorDtos = authors.Select(author => new GetAuthorDtos
            {
                Id = author.Id,
                Name = author.Name,
                Country = author.Country,
                DOB = author.DOB,
            }).ToList();

            return getAuthorDtos;

        }

    }
}
