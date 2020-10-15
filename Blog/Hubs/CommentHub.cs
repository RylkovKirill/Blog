using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Blog.Hubs
{
    public class CommentHub : Hub
    {
        public async Task Send(string message, string user, string data)
        {
            await Clients.All.SendAsync("Send", message, user, data);
        }
    }
}
