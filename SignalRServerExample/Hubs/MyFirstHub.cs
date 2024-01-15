using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MyFirstHub : Hub
    {
        static List<string> clients = new List<string>();
        public async Task SendMessage(string message)
        {
            // receievedMessage is named on client-side
            await Clients.All.SendAsync("receivedMessage",message);
        }
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients",clients);
            await Clients.All.SendAsync("userConnected", Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userDisconnected", Context.ConnectionId);
        }
    }
}
