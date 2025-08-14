using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private  readonly ReaderProfileService _readerProfileService;
        public GroupController(ReaderProfileService readerProfileService)
        {
            _readerProfileService = readerProfileService;
        }
        
        public IActionResult Post([FromBody] string value)
        {
            _logger.LogInformation("Post method called in GroupController with value: {Value}", value);
            return CreatedAtAction(nameof(Get), new { id = 1 }, value);
        }
    }
}
