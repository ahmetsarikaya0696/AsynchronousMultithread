using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            Thread.Sleep(5000);
            var myTask = new HttpClient().GetStringAsync("https://www.google.com");
            var data = await myTask;
            return Ok(data);
        }

    }
}
