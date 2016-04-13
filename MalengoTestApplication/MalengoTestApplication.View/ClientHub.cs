using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MalengoTestApplication.View
{
    [HubName("clientHub")]
    public class ClientHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}