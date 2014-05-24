using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika
{
    public class Ocena
    {
        public int id { get; set; }

        public int wyglad_firmy { get; set; }
        public int poziom_obslugi {get; set;}
        public int czas_swiadczenia_uslug { get; set; }
        public int lokalizacja {get; set;}
        public int poziom_swiadczonej_uslugi {get; set;}
        public int atmosera {get; set;}
        public int zarobki {get; set;}
        public int kontakt_z_przelozonymi {get; set;}
        public int wyposazenie {get; set;}

        public virtual Firma firma { get; set; }

        public virtual Uzytkownik uzytkownik { get; set; }

        private static Ocena _Null = new Ocena
        {
            id = -1,
            wyglad_firmy = 0,
            poziom_obslugi = 0,
            czas_swiadczenia_uslug = 0,
            lokalizacja = 0,
            poziom_swiadczonej_uslugi = 0,
            atmosera = 0,
            zarobki = 0,
            kontakt_z_przelozonymi = 0,
            wyposazenie = 0,
            firma = new Firma(),
            uzytkownik = new Uzytkownik(),
        };

        public static Ocena Null
        {
            get
            {
                return _Null;
            }
        }
    }
}
