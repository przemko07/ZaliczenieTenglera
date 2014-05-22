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
        public ZbiorFunkcji(IZbiorDanych dane)
        {
            this.dane = dane;
        }

        public void OcenienieKomentarzaPozytywnie(int id_komentarz, string id_uzytkownik)
        {
            OcenienieKomentarzaPozytywnie(
                dane.Komentarze.Wczytaj().FirstOrDefault(n => n.id == id_komentarz),
                dane.Uzytkownicy.Wczytaj().FirstOrDefault(n => n.Id == id_uzytkownik));
        }
        public void OcenienieKomentarzaPozytywnie(Logika.Komentarz komentarz, Logika.Uzytkownik uzytkownik)
        {
            if (komentarz == null) throw new BrakKomentarza();
            if (uzytkownik == null) throw new BrakUzytkownika();
            if (uzytkownik.wystawione_komentarze.Count(n => n.id == komentarz.id) > 0) throw new UzytkownikOceniaWlasnyKomentarz();
            if (komentarz.uzytkownicy_korzy_ocenili.Count(n => n.Id == uzytkownik.Id) > 0) throw new UzytkownikOceniaKomentarzKolejnyRaz();

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
            OcenienieKomentarzaNegatywnie(
                dane.Komentarze.Wczytaj().FirstOrDefault(n => n.id == id_komentarz),
                dane.Uzytkownicy.Wczytaj().FirstOrDefault(n => n.Id == id_uzytkownik));
        }

        public void OcenienieKomentarzaNegatywnie(Logika.Komentarz komentarz, Logika.Uzytkownik uzytkownik)
        {
            if (komentarz == null) throw new BrakKomentarza();
            if (uzytkownik == null) throw new BrakUzytkownika();
            if (uzytkownik.wystawione_komentarze.Count(n => n.id == komentarz.id) > 0) throw new UzytkownikOceniaWlasnyKomentarz();
            if (komentarz.uzytkownicy_korzy_ocenili.Count(n => n.Id == uzytkownik.Id) > 0) throw new UzytkownikOceniaKomentarzKolejnyRaz();

            if (komentarz.uzytkownicy_korzy_ocenili == null) komentarz.uzytkownicy_korzy_ocenili = new List<Uzytkownik>();
            if (uzytkownik.ocenione_komentarze == null) uzytkownik.ocenione_komentarze = new List<Komentarz>();

            komentarz.ocena -= 1;
            komentarz.uzytkownicy_korzy_ocenili.Add(uzytkownik);
            uzytkownik.ocenione_komentarze.Add(komentarz);

            dane.Komentarze.Popraw(komentarz);
            dane.Uzytkownicy.Popraw(uzytkownik);
        }

        public IEnumerable<Logika.Firma> PobierzNajlepszeFirmy()
        {
            return dane.Firmy.Wczytaj().OrderBy(n => Srednia(ObliczSredniaOceneFirmy(n)));
        }

        public IEnumerable<Logika.Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka)
        {
            // if (PobierzNajlepszeFirmy().Skip(paczka * 10).Take(10).Count() != 0) 
            return PobierzNajlepszeFirmy().Skip(paczka * 10).Take(10);
        }

        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmy(int id_firma)
        {
            return dane.Komentarze.Wczytaj().Where(n => n.firma.id == id_firma).OrderBy(n => n.ocena);
        }
        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmy(Logika.Firma firma)
        {
            return firma.komentarze.OrderBy(n => n.ocena);
        }

        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(int id_firmy, int paczka)
        {
            return PobierzNajlepszeKomentarzeFirmyWedlogPaczki(dane.Firmy.Wczytaj().FirstOrDefault(n => n.id == id_firmy), paczka);
            //dane.Komentarze.Wczytaj().Where(n => n.firma.id == id_firmy).OrderBy(n => n.ocena);
        }

        public IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(Logika.Firma firma, int paczka)
        {
            return firma.komentarze.OrderBy(n => n.ocena);
        }
        public void ZarejestrujFirmeUzytkownika(string id_uzytkownik, int id_firma)
        {
            ZarejestrujFirmeUzytkownika(dane.Uzytkownicy.Wczytaj().FirstOrDefault(n => n.Id == id_uzytkownik), dane.Firmy.Wczytaj().FirstOrDefault(n => n.id == id_firma));
        }
        public void ZarejestrujFirmeUzytkownika(Logika.Uzytkownik uzytkownik, Logika.Firma firma)
        {
            if (uzytkownik == null) throw new BrakUzytkownika();
            if (firma == null) throw new BrakFirmy();
            if (uzytkownik.firma != null) throw new UzytkownikDodajeDrugaFirme();
            uzytkownik.firma = firma;
            firma.wlasciciel = uzytkownik;
        }

        public void WystawOceneFirmie(string id_uzytkownik, int id_firma, int id_ocena)
        {
            WystawOceneFirmie(dane.Uzytkownicy.Wczytaj().FirstOrDefault(n => n.Id == id_uzytkownik), dane.Firmy.Wczytaj().FirstOrDefault(n => n.id == id_firma), dane.Oceny.Wczytaj().FirstOrDefault(n => n.id == id_ocena));
        }
        public void WystawOceneFirmie(Logika.Uzytkownik uzytkownik, Logika.Firma firma, Logika.Ocena ocena)
        {
            if (uzytkownik == null) throw new BrakUzytkownika();
            if (ocena == null) throw new BrakOceny();
            if (firma == null) throw new BrakFirmy();
            if (firma.komentarze.Count(n => n.wlasciciel.Id == uzytkownik.Id) > 0) throw new UzytkownikOceniaFirmePoRazDrugi();
            if (firma.wlasciciel.Id == uzytkownik.Id) throw new UzytkownikOceniaWlasnaFirme();
            if (firma.oceny == null) firma.oceny = new List<Ocena>();
            if (uzytkownik.oceny_firm == null) uzytkownik.oceny_firm = new List<Ocena>();

            firma.oceny.Add(ocena);
            uzytkownik.oceny_firm.Add(ocena);
            ocena.firma = firma;
            ocena.uzytkownik = uzytkownik;
        }

        public void WystawKomentarzFirmie(string id_uzytkownik, int id_firma, int id_komentarz)
        {
            WystawKomentarzFirmie(dane.Uzytkownicy.Wczytaj().FirstOrDefault(n => n.Id == id_uzytkownik), dane.Firmy.Wczytaj().FirstOrDefault(n => n.id == id_firma), dane.Komentarze.Wczytaj().FirstOrDefault(n => n.id == id_komentarz));
        }
        public void WystawKomentarzFirmie(Logika.Uzytkownik uzytkownik, Logika.Firma firma, Logika.Komentarz komentarz)
        {
            if (uzytkownik == null) throw new BrakUzytkownika();
            if (firma == null) throw new BrakFirmy();
            if (komentarz == null) throw new BrakKomentarza();
            if (uzytkownik.wystawione_komentarze.Count(n => n.firma.id == firma.id) > 0) throw new UzytkownikDodajeDrugiKomentarz();
            if (firma.wlasciciel.Id == uzytkownik.Id) throw new UzytkownikKomentujeWlasnaFirme();

            if (uzytkownik.wystawione_komentarze == null) uzytkownik.wystawione_komentarze = new List<Komentarz>();
            if (firma.komentarze == null) firma.komentarze = new List<Komentarz>();

            uzytkownik.wystawione_komentarze.Add(komentarz);
            firma.komentarze.Add(komentarz);
            komentarz.wlasciciel = uzytkownik;
            komentarz.firma = firma;

        }

        public Logika.Ocena ObliczSredniaOceneFirmy(Logika.Firma firma)
        {
            if (firma.oceny.Count == 0) throw new BrakOcen();
            if (firma.oceny.Count == 1) return firma.oceny.ElementAt(0);
            else
            {
                Ocena ocena = new Ocena();
                foreach (var q in firma.oceny)
                {
                    ocena.atmosera += q.atmosera;
                    ocena.czas_swiadczenia_uslug += q.czas_swiadczenia_uslug;
                    ocena.kontakt_z_przelozonymi += q.kontakt_z_przelozonymi;
                    ocena.lokalizacja += q.lokalizacja;
                    ocena.poziom_obslugi += q.poziom_obslugi;
                    ocena.poziom_swiadczonej_uslugi += q.poziom_swiadczonej_uslugi;
                    ocena.wyglad_firmy += q.wyglad_firmy;
                    ocena.wyposazenie += q.wyposazenie;
                    ocena.zarobki += q.zarobki;
                }
                ocena.atmosera = ocena.atmosera / firma.oceny.Count;
                ocena.czas_swiadczenia_uslug = ocena.czas_swiadczenia_uslug / firma.oceny.Count;
                ocena.kontakt_z_przelozonymi = ocena.kontakt_z_przelozonymi / firma.oceny.Count;
                ocena.lokalizacja = ocena.lokalizacja / firma.oceny.Count;
                ocena.poziom_obslugi = ocena.poziom_obslugi / firma.oceny.Count;
                ocena.poziom_swiadczonej_uslugi = ocena.poziom_swiadczonej_uslugi / firma.oceny.Count;
                ocena.wyglad_firmy = ocena.wyglad_firmy / firma.oceny.Count;
                ocena.wyposazenie = ocena.wyposazenie / firma.oceny.Count;
                ocena.zarobki = ocena.zarobki / firma.oceny.Count;
                return ocena;
            }
        }

        public Logika.Ocena ObliczSredniaOceneFirmy(int id_firma)
        {
            return ObliczSredniaOceneFirmy(dane.Firmy.Wczytaj().FirstOrDefault(n => n.id == id_firma));
        }

        public double Srednia(Logika.Ocena ocena)
        {
            double srednia;
            srednia = ocena.atmosera + ocena.czas_swiadczenia_uslug + ocena.kontakt_z_przelozonymi + ocena.lokalizacja + ocena.poziom_obslugi + ocena.poziom_swiadczonej_uslugi + ocena.wyglad_firmy + ocena.wyposazenie + ocena.zarobki / 9;
            return srednia;
        }

        public Firma PobierzFirmePoId(int id_firmy)
        {
            return new Firma();
        }
    }
}
