using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestOLController : ControllerBase
    {
        private readonly TestService _testService;

        public TestOLController(TestService testService)
        {
            _testService = testService;
        }

        // 1. UPDATED: Now accepts pagination parameters from the URL
        // Example: api/test?pageNumber=1&pageSize=50
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            // Call your service passing the requested page and size
            var testData = await _testService.Handle(pageNumber, pageSize);

            return Ok(testData);
        }

        // 2. UNCHANGED: Kept exactly as you had it
        [HttpGet("load-cache")]
        public async Task<IActionResult> LoadCache(CancellationToken cancellationToken)
        {
            await _testService.LoadOlWorksIntoRedisAsync(cancellationToken);

            return Ok(new
            {
                Message = "OL Works data loaded into Redis successfully."
            });
        }






        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    var testData = await _testService.GetAllTestDataAsync();
        //    return Ok(testData);
        //}

        //[HttpGet("load-cache")]
        //public async Task<IActionResult> LoadCache(CancellationToken cancellationToken)
        //{
        //    await _testService.LoadOlWorksIntoRedisAsync(cancellationToken);

        //    return Ok(new
        //    {
        //        Message = "OL Works data loaded into Redis successfully."
        //    });
        //}



    }
}
