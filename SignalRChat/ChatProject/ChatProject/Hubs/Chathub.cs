using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace ChatProject.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string groupName)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);

        }

        public async Task AddToGroup(string user, string message, string groupName)
        {
            //RemoveFromGroup("1");
            //RemoveFromGroup("2");
            //RemoveFromGroup("3");
            //RemoveFromGroup("4");
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{user} har sluttet sig til chat{groupName}.", message);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            //await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} har forladt chat{groupName}.");
        }
    }
}