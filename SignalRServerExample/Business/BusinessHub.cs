using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Business
{
    public class BusinessHub
    {
        private readonly IHubContext<MyFirstHub> _hubContext;

        public BusinessHub(IHubContext<MyFirstHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            // receievedMessage is named on client-side
            await _hubContext.Clients.All.SendAsync("receivedMessage", message);
        }

    }
}
