using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika
{
    public class Komentarz
    {
        public int id { get; set; }

        public int ocena { get; set; }

        public string tresc { get; set; }

        public virtual Firma firma { get; set; }
    }
}
