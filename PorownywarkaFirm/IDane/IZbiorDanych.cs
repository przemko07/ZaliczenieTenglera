using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorDanych
        : IZbiorAdresow,
        IZbiorFirm,
        IZbiorKomentarzy,
        IZbiorKontaktow,
        IZbiorOcen,
        IZbiorUzytkownikow
    {
        #region pomocnik
        IZbiorAdresow Adresy { get; }
        IZbiorFirm Firmy { get; }
        IZbiorKomentarzy Komentarze { get; }
        IZbiorKontaktow Kontakty { get; }
        IZbiorOcen Oceny { get; }
        IZbiorUzytkownikow Uzytkownicy { get; }
        #endregion

        #region DB Context
        object DBContext { get; }
        #endregion
    }
}
