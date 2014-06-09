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
        public int wyglad_firmy { get; set; }
        public int poziom_obslugi { get; set; }
        public int czas_swiadczenia_uslug { get; set; }
        public int lokalizacja { get; set; }
        public int poziom_swiadczonej_uslugi { get; set; }
        public int atmosera { get; set; }
        public int zarobki { get; set; }
        public int kontakt_z_przelozonymi { get; set; }
        public int wyposazenie { get; set; }

        public OcenaFirmyVM(Firma firma)
            : base(firma)
        {
        }

        public OcenaFirmyVM()
        {

        }

        public Ocena StworzOcene()
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
                wyposazenie = this.wyposazenie
            };
        }
    }
}