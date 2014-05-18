using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorKontaktow
    {
        void Zapisz(Kontakt kontakt);
        void Popraw(Kontakt kontakt);
        void Usun(Kontakt kontakt);
        IEnumerable<Kontakt> Wczytaj();
    }
}
