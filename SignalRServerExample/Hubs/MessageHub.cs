using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        /** 
         * Caller
         * sadece client'a istek atan client
         * All
         * server'a bağlı olan herkes ile
         * Other 
         * server'a istek atan client dışında tüm clientlera mesaj gönderirr
         * */
        public async Task SendMessageAsync(string message)
        {
            await Clients.Others.SendAsync("receivedMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId",Context.ConnectionId);
        }
    }
}
