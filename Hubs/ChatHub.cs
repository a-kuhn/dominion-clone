using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DominionClone.Hubs
{
    // Inhetiring from Hub class, which manages connections, groups, and messaging
    public class ChatHub : Hub
    {
        // Can be called by a connected client to send a message to all clients
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        
    }
}