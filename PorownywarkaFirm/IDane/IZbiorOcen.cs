using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorOcen
    {
        void Zapisz(Ocena ocena);
        void Popraw(Ocena ocena);
        void Usun(Ocena ocena);
        IEnumerable<Ocena> Wczytaj();
    }
}
