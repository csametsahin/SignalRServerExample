using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MyFirstHub : Hub
    {
        public async Task SendMessage(string message)
        {
            // receievedMessage is named on client-side
            await Clients.All.SendAsync("receivedMessage",message);
        }
    }
}
