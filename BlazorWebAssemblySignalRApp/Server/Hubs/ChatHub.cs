using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System;

namespace BlazorWebAssemblySignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToOthers(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToMyself(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendPingToOthers(string user)
        {
            await Clients.Others.SendAsync("PingMessage", user);
        }

         public async Task SendPingMyself(string user)
        {
            var rand = new Random();
            int numberFromServer = rand.Next(1000);

            await Clients.Caller.SendAsync("PingMyself", user,numberFromServer);
        }

    }
}