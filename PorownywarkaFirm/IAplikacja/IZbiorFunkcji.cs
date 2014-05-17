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
        public void OcenienieKomentarzaPozytywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        public void OcenienieKomentarzaNegatywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        public IEnumerable<Firma> PobierzNajlepszeFirmy();

        public IEnumerable<Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka);

        public IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmy(Firma firma);

        public IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(int paczka);

        public void ZarejestrujFirmeUzytkownika(Uzytkownik uzytkownik, Firma firma);

        public void WystawOceneFirmie(Uzytkownik uzytkownik, Firma firma, Ocena ocena);

        public void WystawKomentarzFirmie(Uzytkownik uzytkownik, Firma firma, Komentarz komentarz);

        public Ocena ObliczSredniaOceneFirmy(Firma firma);
    }
}
