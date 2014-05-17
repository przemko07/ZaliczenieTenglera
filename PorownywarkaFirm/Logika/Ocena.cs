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

        public virtual Firma firma { get; set; }
    }
}
