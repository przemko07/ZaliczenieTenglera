using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.Hubs
{
    public interface IMessage
    {
        void SendMessageToUser(string username, string message);

        void SendMessageToAll(string message);
    }
}
