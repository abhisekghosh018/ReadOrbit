using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadOrbit.APPLICATION.Services;

namespace ReadOrbit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private  readonly GroupService _groupService;
        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }         
    }
}
