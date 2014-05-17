using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAplikacja
{
    public interface IZbiorFunkcji
    {
        void OcenienieKomentarzaPozytywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        void OcenienieKomentarzaNegatywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        IEnumerable<Firma> PobierzNajlepszeFirmy();

        IEnumerable<Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka);

        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmy(Firma firma);

        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(int paczka);

        void ZarejestrujFirmeUzytkownika(Uzytkownik uzytkownik, Firma firma);

        void WystawOceneFirmie(Uzytkownik uzytkownik, Firma firma, Ocena ocena);

        void WystawKomentarzFirmie(Uzytkownik uzytkownik, Firma firma, Komentarz komentarz);

        Ocena ObliczSredniaOceneFirmy(Firma firma);
    }
}
