using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika
{
    public class Kontakt
    {
        public int id { get; set; }

        public string mail { get; set; }

        public string numer_komurkowy { get; set; }

        public virtual Firma firma { get; set; }
    }
}
