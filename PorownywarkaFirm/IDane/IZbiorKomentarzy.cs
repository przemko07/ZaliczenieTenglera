using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorKomentarzy
    {
        void Zapisz(Komentarz komentarz);
        void Popraw(Komentarz komentarz);
        void Usun(Komentarz komentarz);
        IEnumerable<Komentarz> Wczytaj();
    }
}
