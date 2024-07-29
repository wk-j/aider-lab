using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController(ILogger<HelloController> logger) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("Hello endpoint called");
            return Ok("Hello, World!");
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            logger.LogInformation("Hello endpoint called with name: {Name}", name);
            return Ok($"Hello, {name}!");
        }
    }
}
