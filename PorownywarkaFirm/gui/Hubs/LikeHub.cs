using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.Hubs
{
    [HubName("LikeHub")]
    public class LikeHub : Hub
    {
        [HubMethodName("OcenKomentarz")]
        public void OcenKomentarz(int id_komentarza, int ocena)
        {
            Clients.Others.PobierzOcene(id_komentarza, ocena);
        }
    }
}