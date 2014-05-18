using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorFirm
    {
        void Zapisz(Firma firma);
        void Popraw(Firma firma);
        void Usun(Firma firma);
        IEnumerable<Firma> Wczytaj();
    }
}
