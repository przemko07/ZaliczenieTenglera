using IAplikacja;
using IDane;
using Logika;
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
        //public ZbiorFunkcji(IZbiorDanych dane)
        //{
        //    this.dane = dane;
        //}
        public ZbiorFunkcji()
        {
            
        }

        public void OcenienieKomentarzaPozytywnie(int id_komentarz, string id_uzytkownik)
        {
            OcenienieKomentarzaPozytywnie(
                dane.Komentarze.Wczytaj().FirstOrDefault(n=>n.id == id_komentarz),
                dane.Uzytkownicy.Wczytaj().FirstOrDefault(n=>n.Id == id_uzytkownik));
        }
        public void OcenienieKomentarzaPozytywnie(Logika.Komentarz komentarz, Logika.Uzytkownik uzytkownik)
        {
            if (komentarz == null) throw new BrakKomentarza();
            if (uzytkownik == null) throw new BrakUzytkownika();
            if (uzytkownik.wystawione_komentarze.Count(n => n.id == komentarz.id) > 0) throw new UzytkownikOceniaSiebie();
            if (komentarz.uzytkownicy_korzy_ocenili.Count(n => n.Id == uzytkownik.Id) > 0) throw new UzytkownikOceniaKolejnyRaz();

            if (komentarz.uzytkownicy_korzy_ocenili == null) komentarz.uzytkownicy_korzy_ocenili = new List<Uzytkownik>();
            if (uzytkownik.ocenione_komentarze == null) uzytkownik.ocenione_komentarze = new List<Komentarz>();

            komentarz.ocena += 1;
            komentarz.uzytkownicy_korzy_ocenili.Add(uzytkownik);
            uzytkownik.ocenione_komentarze.Add(komentarz);

            dane.Komentarze.Popraw(komentarz);
            dane.Uzytkownicy.Popraw(uzytkownik);
        }

        public void OcenienieKomentarzaNegatywnie(int id_komentarz, string id_uzytkownik)
        {
            throw new NotImplementedException();
        }
        public void OcenienieKomentarzaNegatywnie(Logika.Komentarz komentarz, Logika.Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logika.Firma> PobierzNajlepszeFirmy()
        {
            return new[]
            {
                new Firma()
            };
        }

        public IEnumerable<Logika.Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmy(int id_firma)
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

        public void ZarejestrujFirmeUzytkownika(string id_uzytkownik, int id_firma)
        {
            throw new NotImplementedException();
        }
        public void ZarejestrujFirmeUzytkownika(Logika.Uzytkownik uzytkownik, Logika.Firma firma)
        {
            throw new NotImplementedException();
        }

        public void WystawOceneFirmie(string id_uzytkownik, int id_firma, int id_ocena)
        {
            throw new NotImplementedException();
        }
        public void WystawOceneFirmie(Logika.Uzytkownik uzytkownik, Logika.Firma firma, Logika.Ocena ocena)
        {
            throw new NotImplementedException();
        }

        public void WystawKomentarzFirmie(string id_uzytkownik, int id_firma, int id_komentarz)
        {
            throw new NotImplementedException();
        }
        public void WystawKomentarzFirmie(Logika.Uzytkownik uzytkownik, Logika.Firma firma, Logika.Komentarz komentarz)
        {
            throw new NotImplementedException();
        }

        public Logika.Ocena ObliczSredniaOceneFirmy(Logika.Firma firma)
        {
            return new Ocena
            {
                atmosera = 1,
                czas_swiadczenia_uslug = 2,
                kontakt_z_przelozonymi = 3,
                lokalizacja = 4,
                poziom_obslugi = 5,
                poziom_swiadczonej_uslugi = 6,
                wyglad_firmy = 7,
                wyposazenie = 8,
                zarobki = 9,
            };
        }
        public Logika.Ocena ObliczSredniaOceneFirmy(int id_firma)
        {
            throw new NotImplementedException();
        }
    }
}
