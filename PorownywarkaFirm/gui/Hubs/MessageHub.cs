using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using IKomunikacja;
using Logika;

namespace gui.Hubs
{
    [HubName("MessageHub")]
    public class MessageHub : Hub, IMessageBus
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

        [HubMethodName("WyslijWiadomoscDoWszystkich")]
        public void WyslijWiadomoscDoWszystkich(string wiadomosc)
        {
            Clients.All.GetMessage(wiadomosc);
        }

        [HubMethodName("WyslijWiadomoscDoUzytkownika")]
        public void WyslijWiadomoscDoUzytkownika(string wiadomosc, Uzytkownik uzytkownik)
        {
            Clients.Group(uzytkownik.UserName).GetMessage(wiadomosc);
        }

        public void FirmaZostalaUtworzona(Logika.Firma firma)
        {
            Clients.All("w servisie pojawiła się nowa firma " + firma.nazwa);
        }

        public void TwojFirmaZostalaOceniona(Logika.Uzytkownik uzytkownik)
        {
            WyslijWiadomoscDoUzytkownika("twoja firma zyskała nową ocene", uzytkownik);
        }


        public void TwojaFirmaZostalaZakomentowana(Uzytkownik uzytkownik, string komentarz)
        {
            WyslijWiadomoscDoUzytkownika(komentarz, uzytkownik); 
        }
    }
}