using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika
{
    public class Adres
    {
        public int id { get; set; }

        public string miasto { get; set; }

        public string ulica { get; set; }

        public string numer_budynku { get; set; }

        public string numer_lokalu { get; set; }

        public virtual Firma firma { get; set; }
    }
}
