using DemoPlatzi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoPlatzi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController:ControllerBase
    {
        IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet(Name = "GetHelloWorld")]
        public IActionResult Get()
        {
            return Ok(_helloWorldService.GetHelloWorld());
        }
    }
}
