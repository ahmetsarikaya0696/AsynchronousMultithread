using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("İstek başladı");
                await Task.Delay(5000, cancellationToken);
                var myTask = new HttpClient().GetStringAsync("https://www.google.com");
                var data = await myTask;
                _logger.LogInformation("İstek bitti");
                return Ok(data);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

    }
}
