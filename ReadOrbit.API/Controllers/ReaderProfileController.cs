using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetReaderProfiles()
        {
            var readerProfiles = await _readerProfileService.GetAllReaderProfileAsync();

            if (readerProfiles == null || !readerProfiles.Any())
            {
                return NoContent();
            }
            return Ok(readerProfiles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReaderProfile([FromBody] CreateUserProfileDTO createUserProfileDTO)
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
    }
}
