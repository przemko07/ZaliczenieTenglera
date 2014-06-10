using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKomunikacja
{
    public interface IMessageBus
    {
        void WyslijWiadomoscDoWszystkich(string wiadomosc);
        void WyslijWiadomoscDoUzytkownika(string wiadomosc, Uzytkownik uzytkownik);
        void FirmaZostalaUtworzona(Firma firma);
        void TwojFirmaZostalaOceniona(Uzytkownik uzytkownik);

        void TwojaFirmaZostalaZakomentowana(Uzytkownik uzytkownik, string komentarz);
    }
}
