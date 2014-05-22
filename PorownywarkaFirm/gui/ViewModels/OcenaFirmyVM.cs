using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class OcenaFirmyVM : FirmaVM
    {
        public int id_firmy { get; set; }
        public string nazwa_firmy { get; set; }
        public string adres_firmy { get; set; }
        public string email_firmy { get; set; }
        public string telefon_firmy { get; set; }

        public int wyglad_firmy { get; set; }
        public int poziom_obslugi { get; set; }
        public int czas_swiadczenia_uslug { get; set; }
        public int lokalizacja { get; set; }
        public int poziom_swiadczonej_uslugi { get; set; }
        public int atmosera { get; set; }
        public int zarobki { get; set; }
        public int kontakt_z_przelozonymi { get; set; }
        public int wyposazenie { get; set; }

        public OcenaFirmyVM(Firma firma, Ocena srednia_ocena)
            : base(firma, srednia_ocena)
        {-
            this.wyglad_firmy = srednia_ocena.wyglad_firmy;
            this.poziom_obslugi = srednia_ocena.poziom_obslugi;
            this.czas_swiadczenia_uslug = srednia_ocena.czas_swiadczenia_uslug;
            this.lokalizacja = srednia_ocena.czas_swiadczenia_uslug;
            this.poziom_swiadczonej_uslugi = srednia_ocena.poziom_swiadczonej_uslugi;
            this.atmosera = srednia_ocena.atmosera;
            this.zarobki = srednia_ocena.zarobki;
            this.kontakt_z_przelozonymi = srednia_ocena.kontakt_z_przelozonymi;
            this.wyposazenie = srednia_ocena.wyposazenie;
        }

        public OcenaFirmyVM()
        {

        }

        public Ocena StworzOcene(Firma firma, Uzytkownik uzytkownik)
        {
            return new Ocena
            {
                wyglad_firmy = this.wyglad_firmy,
                poziom_obslugi = this.poziom_obslugi,
                czas_swiadczenia_uslug = this.czas_swiadczenia_uslug,
                lokalizacja = this.lokalizacja,
                poziom_swiadczonej_uslugi = this.poziom_swiadczonej_uslugi,
                atmosera = this.atmosera,
                zarobki = this.zarobki,
                kontakt_z_przelozonymi = this.kontakt_z_przelozonymi,
                wyposazenie = this.wyposazenie,

                firma = firma,
                uzytkownik = uzytkownik,
            };
        }
    }
}