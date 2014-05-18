using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorAdresow
    {
        void Zapisz(Adres adres);
        void Popraw(Adres adres);
        void Usun(Adres adres);
        IEnumerable<Adres> Wczytaj();
    }
}
