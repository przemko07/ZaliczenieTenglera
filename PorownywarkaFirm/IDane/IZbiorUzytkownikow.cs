using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorUzytkownikow
    {
        void Zapisz(Uzytkownik uzytkownik);
        void Popraw(Uzytkownik uzytkownik);
        void Usun(Uzytkownik uzytkownik);
        IEnumerable<Uzytkownik> Wczytaj();
    }
}
