using Microsoft.AspNetCore.SignalR;
using MrFamilyTree.Models;

namespace MrFamilyTree.Hubs
{
    public class MessageHub : Hub
    {
        public async Task NewMessage(Message msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }
    }
}
