using DemoPlatzi.Models;
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

        // esto es para crear una DB si no existe, segun la configuracion del context Tareas
        TareasContext dbContext;

        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<WeatherForecastController> logger, TareasContext db)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
            dbContext = db;
        }

        [HttpGet(Name = "GetHelloWorld")]
        public IActionResult Get()
        {
            _logger.LogInformation("Retornamos el saludo desde nuestra dependencia de HelloWorld!");
            return Ok(_helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDB()
        {
            dbContext.Database.EnsureCreated();
            return Ok();
        }
    }
}
