using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace gui.Hubs
{
    [HubName("MessageHub")]
    public class MessageHub : Hub, IMessage
    {
        public MessageHub()
        {

        }
        public override System.Threading.Tasks.Task OnConnected()
        {
            var user = Context.User;
            if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
            {
                Groups.Add(Context.ConnectionId, user.Identity.Name);
            }
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            var user = Context.User;
            if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
            {
                Groups.Remove(Context.ConnectionId, user.Identity.Name);
            }
            return base.OnDisconnected();
        }

        [HubMethodName("SendMessageToUser")]
        public void SendMessageToUser(string username, string message)
        {
            Clients.Group(username).GetMessage(message);
        }


        [HubMethodName("SendMessageToAll")]
        public void SendMessageToAll(string message)
        {
            Clients.All.GetMessage(message);
        }
    }
}