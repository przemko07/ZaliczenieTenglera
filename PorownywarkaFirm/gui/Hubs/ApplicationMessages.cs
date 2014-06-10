using IDane;
using IKomunikacja;
using Logika;
using MailMesages;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.Hubs
{
    public class ApplicationMessages : IMessageBus
    {
        private IHubContext hub { get; set; }
        private IMessageBus mail { get; set; }

        public ApplicationMessages(IZbiorDanych dane)
        {
            hub = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            mail = new MailMessages(dane);
        }

        public void WyslijWiadomoscDoWszystkich(string wiadomosc)
        {
            mail.WyslijWiadomoscDoWszystkich(wiadomosc);
            hub.Clients.All.GetMessage(wiadomosc);
        }

        public void WyslijWiadomoscDoUzytkownika(string wiadomosc, Uzytkownik uzytkownik)
        {
            mail.WyslijWiadomoscDoUzytkownika(wiadomosc, uzytkownik);
            hub.Clients.Group(uzytkownik.UserName).GetMessage(wiadomosc);
        }

        public void FirmaZostalaUtworzona(Firma firma)
        {
            mail.FirmaZostalaUtworzona(firma);
            hub.Clients.All.GetMessage("w servisie pojawiła się nowa firma " + firma.nazwa);
        }

        public void TwojFirmaZostalaOceniona(Uzytkownik uzytkownik)
        {
            WyslijWiadomoscDoUzytkownika("twoja firma zyskała nową ocene", uzytkownik);
        }


        public void TwojaFirmaZostalaZakomentowana(Uzytkownik uzytkownik, string komentarz)
        {
            WyslijWiadomoscDoUzytkownika(komentarz, uzytkownik); 
        }
    }
}