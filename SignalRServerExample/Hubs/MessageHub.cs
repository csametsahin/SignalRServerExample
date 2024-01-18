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
         * AllExcept
         * belirtilen clientlar hariç diğerlerine mesaj yolla connectionidye göre filtrelenir
         * Clients.Client
         * ile sadece gönderilen connection idye mesaj gönderilir
         * Group
         * Belirtilen gruptaki tüm clientlera bildiri gönderilir
         * önce gruplar oluşturulmalı ardından clientlar grouplara subscribe olmalı
         * GroupExcept
         * Belirtilen gruptaki belirtilen tüm clientlara mesaj gönderir
         * Clients.GroupExcept(groupName,connectionIds)
         * Groups
         * Clients.Groups(groupNames)
         * OthersInGroup
         * Mesaj gönderen client hariç tüm clientlara mesaj yollar
         * Other 
         * server'a istek atan client dışında tüm clientlera mesaj gönderirr
         * User ve Users
         * authenticated kullanıcılara erişmemizi sağlayan method
         * */
        public async Task SendMessageAsync(string message,string groupName)
        {
            await Clients.Group(groupName).SendAsync("receivedMessage",message);
            //await Clients.Others.SendAsync("receivedMessage", message);
        }
        public async Task AddUserToGroup(string connectionId,string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId",Context.ConnectionId);
        }
    }
}
