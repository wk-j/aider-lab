using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Hello endpoint called");
            return Ok("Hello, World!");
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            _logger.LogInformation("Hello endpoint called with name: {Name}", name);
            return Ok($"Hello, {name}!");
        }
    }
}
