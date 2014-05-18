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
    }
}
