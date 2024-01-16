using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRServerExample.Business;

namespace SignalRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly BusinessHub _business;

        public HomeController(BusinessHub business)
        {
            _business = business;
        }
        [HttpGet("{message}")]
        public async Task<IActionResult> SendMessageAsync(string message)
        {
            await _business.SendMessageAsync(message);
            return Ok();
        }
    }
}
