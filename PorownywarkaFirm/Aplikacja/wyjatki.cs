using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    public class UzytkownikOceniaWlasnyKomentarz : Exception { }
    public class UzytkownikOceniaKomentarzKolejnyRaz : Exception { }
    public class BrakKomentarza : Exception { }
    public class BrakUzytkownika : Exception { }
    public class BrakOcen : Exception { }
    public class BrakFirmy : Exception { }
    public class UzytkownikDodajeDrugaFirme : Exception { }
    public class UzytkownikDodajeDrugiKomentarz : Exception { }
    public class BrakOceny : Exception { }
    public class UzytkownikOceniaFirmePoRazDrugi : Exception { }
    public class UzytkownikOceniaWlasnaFirme : Exception { }
    public class UzytkownikKomentujeWlasnaFirme : Exception { }
}
