using DemoPlatzi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoPlatzi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService _helloWorldService;
        private readonly ILogger<WeatherForecastController> _logger;

        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<WeatherForecastController> logger)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
        }

        [HttpGet(Name = "GetHelloWorld")]
        public IActionResult Get()
        {
            _logger.LogInformation("Retornamos el saludo desde nuestra dependencia de HelloWorld!");
            return Ok(_helloWorldService.GetHelloWorld());
        }
    }
}
