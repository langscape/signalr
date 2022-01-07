using Microsoft.AspNetCore.SignalR;
using signalr.Api.Models;
using System.Threading.Tasks;

namespace signalr.Api.Hubs
{
    public class ProductivityHub : Hub
    { 
        public async Task SendMessage(Productivity productivity)
        {
            await Clients.All.SendAsync("Productivity", productivity);
        }
    }
}