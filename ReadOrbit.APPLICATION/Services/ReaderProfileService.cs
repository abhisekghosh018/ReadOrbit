using ReadOrbit.APPLICATION.DTOs.GroupDtos;
using ReadOrbit.APPLICATION.DTOs.ReaderProfileDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.Services
{
    public class ReaderProfileService
    {
        private readonly IReaderProfileRepository _readerProfileRepository;
        public ReaderProfileService(IReaderProfileRepository readerProfileRepository)
        {
            _readerProfileRepository = readerProfileRepository;
        }
        public async Task<int> CreateReaderProfileAsync(CreateReaderProfileDTO createUserProfileDTO)
        {
            if (createUserProfileDTO == null) return 0;

            var readerProfile = new ReaderProfile
            {
                Id = createUserProfileDTO.Id,
                FavoriteGenre = createUserProfileDTO.FavoriteGenre,
                Bio = createUserProfileDTO.Bio,
                AvatarUrl = createUserProfileDTO.AvatarUrl
            };

            var newReaderProfile = await _readerProfileRepository.CreateReaderProfileAsync(readerProfile);
            return newReaderProfile;
        }
        public async Task<GetReaderProfileDTO> GetReaderProfileByIdAsync(string Id)
        {
            var readerProlie = await _readerProfileRepository.GetReaderProfileByIdAsync(Id);
            if (readerProlie == null) return null;

            var UserProfiDto = new GetReaderProfileDTO
            {
                Id = readerProlie.Id,
                FavoriteGenre = readerProlie.FavoriteGenre,
                AvatarUrl = readerProlie.AvatarUrl,
                Bio = readerProlie.Bio
            };
            return UserProfiDto;
        }
        public async Task<IEnumerable<GetReaderProfileDTO>> GetAllReaderProfileAsync()
        {
            var readerProfile = await _readerProfileRepository.GetAllReaderProfileAsync();
            return readerProfile.Select(g => new GetReaderProfileDTO
            {
                Id = g.Id,
                FavoriteGenre = g.FavoriteGenre,
                AvatarUrl = g.AvatarUrl,
                Bio = g.Bio

            }).ToList();
        }
        public async Task<int> UpdateReaderProfileAsync(UpdateReaderProfileDTO updateReaderProfileDTO)
        {
            if (updateReaderProfileDTO == null) return 0;

            var existingReaderProfile = await _readerProfileRepository.GetReaderProfileByIdAsync(updateReaderProfileDTO.Id);

            if (existingReaderProfile == null) return 0;

            if (updateReaderProfileDTO.Bio != null)
            {
                existingReaderProfile.Bio = updateReaderProfileDTO.Bio;
            }
            if (existingReaderProfile.AvatarUrl != null)
            {
                existingReaderProfile.AvatarUrl = updateReaderProfileDTO.AvatarUrl;
            }
            if (existingReaderProfile.FavoriteGenre != null)
            {
                existingReaderProfile.FavoriteGenre = updateReaderProfileDTO.FavoriteGenre;
            }

            var updatedGroup = await _readerProfileRepository.UpdateReaderProfileAsync(existingReaderProfile);
            return updatedGroup;
        }
    }
}
