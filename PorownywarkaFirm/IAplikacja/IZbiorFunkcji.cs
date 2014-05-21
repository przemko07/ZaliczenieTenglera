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
        void OcenienieKomentarzaPozytywnie(int id_komentarz, string id_uzytkownik);
        void OcenienieKomentarzaPozytywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        void OcenienieKomentarzaNegatywnie(int id_komentarz, string id_uzytkownik);
        void OcenienieKomentarzaNegatywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        IEnumerable<Firma> PobierzNajlepszeFirmy();

        IEnumerable<Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka);

        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmy(int id_firma);
        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmy(Firma firma);

        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(int id_firmy, int paczka);
        IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(Logika.Firma firma, int paczka);

        void ZarejestrujFirmeUzytkownika(string id_uzytkownik, int id_firma);
        void ZarejestrujFirmeUzytkownika(Uzytkownik uzytkownik, Firma firma);

        void WystawOceneFirmie(string id_uzytkownik, int id_firma, int id_ocena);
        void WystawOceneFirmie(Uzytkownik uzytkownik, Firma firma, Ocena ocena);

        void WystawKomentarzFirmie(string id_uzytkownik, int id_firma, int id_komentarz);
        void WystawKomentarzFirmie(Uzytkownik uzytkownik, Firma firma, Komentarz komentarz);

        Ocena ObliczSredniaOceneFirmy(Firma firma);
        Ocena ObliczSredniaOceneFirmy(int id_firma);
    }
}
