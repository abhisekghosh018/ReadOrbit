using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.DTOs.ReaderProfileDTOs;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderProfileController : ControllerBase
    {
        private readonly ReaderProfileService _readerProfileService;

        public ReaderProfileController(ReaderProfileService readerProfileService)
        {
            _readerProfileService = readerProfileService;
        }

        [HttpGet("GetReaderProfiles")]
        public async Task<IActionResult> GetReaderProfiles()
        {
            var readerProfiles = await _readerProfileService.GetAllReaderProfileAsync();

            if (readerProfiles == null || !readerProfiles.Any())
            {
                return NoContent();
            }
            return Ok(readerProfiles);
        }

        [HttpGet("getReaderProfileById/{id}")]
        public async Task<IActionResult> GetReaderProfileById(string id)
        {
            var readerProfile = await _readerProfileService.GetReaderProfileByIdAsync(id);
            if (readerProfile == null)
            {
                return NoContent();
            }
            return Ok(readerProfile);
        }

        [HttpPost("CreateReaderProfile")]
        public async Task<IActionResult> CreateReaderProfile([FromBody] CreateReaderProfileDTO createUserProfileDTO)
        {
            if (createUserProfileDTO == null)
            {
                return BadRequest("Value cannot be null or empty.");
            }
            var result = await _readerProfileService.CreateReaderProfileAsync(createUserProfileDTO);
            if (result == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpPut("updateReaderProfile")]
        public async Task<IActionResult> UpdateReaderProfile([FromBody] UpdateReaderProfileDTO UpdateReaderProfileDTO)
        {
            if (UpdateReaderProfileDTO == null)
            {
                return BadRequest("Value cannot be null or empty.");
            }

            var existingProfile = await _readerProfileService.GetReaderProfileByIdAsync(UpdateReaderProfileDTO.Id);

            if (existingProfile == null)
            {
                return NotFound("Reader profile not found.");
            }

            var result = await _readerProfileService.UpdateReaderProfileAsync(UpdateReaderProfileDTO);           
            return Ok(result);
        }
    }
}
