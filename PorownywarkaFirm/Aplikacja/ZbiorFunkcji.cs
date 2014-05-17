using IAplikacja;
using IDane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    public class ZbiorFunkcji : IZbiorFunkcji
    {
        public IZbiorDanych dane { get; set; }

        public ZbiorFunkcji(IZbiorDanych dane)
        {
            this.dane = dane;
        }
        public void OcenienieKomentarzaPozytywnie(Logika.Komentarz komentarz, Logika.Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }

        public void OcenienieKomentarzaNegatywnie(Logika.Komentarz komentarz, Logika.Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logika.Firma> PobierzNajlepszeFirmy()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logika.Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmy(Logika.Firma firma)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(int paczka)
        {
            throw new NotImplementedException();
        }

        public void ZarejestrujFirmeUzytkownika(Logika.Uzytkownik uzytkownik, Logika.Firma firma)
        {
            throw new NotImplementedException();
        }

        public void WystawOceneFirmie(Logika.Uzytkownik uzytkownik, Logika.Firma firma, Logika.Ocena ocena)
        {
            throw new NotImplementedException();
        }

        public void WystawKomentarzFirmie(Logika.Uzytkownik uzytkownik, Logika.Firma firma, Logika.Komentarz komentarz)
        {
            throw new NotImplementedException();
        }

        public Logika.Ocena ObliczSredniaOceneFirmy(Logika.Firma firma)
        {
            throw new NotImplementedException();
        }
    }
}
