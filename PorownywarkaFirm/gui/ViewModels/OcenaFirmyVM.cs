using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class OcenaCzastkowa : DisplayNameAttribute
    {
        public OcenaCzastkowa()
            : base()
        {
        }
        public OcenaCzastkowa(string name)
            : base(name)
        {
        }
    }
    public class OcenaFirmyVM : FirmaVM
    {
        [OcenaCzastkowa("Wygląd firmy")]
        public int wyglad_firmy { get; set; }

        [OcenaCzastkowa("Poziom obsługi")]
        public int poziom_obslugi { get; set; }

        [OcenaCzastkowa("Czas usług")]
        public int czas_swiadczenia_uslug { get; set; }

        [OcenaCzastkowa("Lokalizacja")]
        public int lokalizacja { get; set; }

        [OcenaCzastkowa("Poziom usług")]
        public int poziom_swiadczonej_uslugi { get; set; }

        [OcenaCzastkowa("Atmosfera")]
        public int atmosera { get; set; }

        [OcenaCzastkowa("Zarobki")]
        public int zarobki { get; set; }

        [OcenaCzastkowa("Kontakt z przełożonym")]
        public int kontakt_z_przelozonymi { get; set; }

        [OcenaCzastkowa("Wyposażenie")]
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