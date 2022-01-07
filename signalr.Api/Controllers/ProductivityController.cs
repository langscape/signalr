using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalr.Api.Hubs;
using signalr.Api.Models;
using System.Threading.Tasks;

namespace signalr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductivityController : ControllerBase
    {
        private readonly IHubContext<ProductivityHub> _productivityHub;

        public ProductivityController(IHubContext<ProductivityHub> productivity)
        {
            _productivityHub = productivity;
        }

        [HttpPost]
        public async Task<IActionResult> PostProductivity(Productivity productivity)
        {
            await _productivityHub.Clients.All.SendAsync("Productivity", productivity);
            return Ok();
        }
    }
}