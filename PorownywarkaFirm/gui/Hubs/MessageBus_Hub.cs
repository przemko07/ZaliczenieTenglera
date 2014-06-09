using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.Hubs
{
    public class MessageBus_Hub : IMessage
    {
        private IHubContext _context;

        public MessageBus_Hub()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
        }
        public void SendMessageToUser(string username, string message)
        {
            _context.Clients.Group(username).GetMessage(message);
        }

        public void SendMessageToAll(string message)
        {
            _context.Clients.All.GetMessage(message);
        }
    }
}