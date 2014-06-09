using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAplikacja
{
    public interface IZbiorFunkcji
    {
        void OcenienieKomentarzaPozytywnie(int id_komentarz, string id_uzytkownik);
        void OcenienieKomentarzaPozytywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        void OcenienieKomentarzaNegatywnie(int id_komentarz, string id_uzytkownik);
        void OcenienieKomentarzaNegatywnie(Komentarz komentarz, Uzytkownik uzytkownik);

        /// <summary>
        /// Pobiera wszystkie firmy z bazy, w porządku od najlespzej do najgorszej
        /// </summary>
        /// <returns>firmy z bazy w porządku od najlepszej do najgorszej</returns>
        IEnumerable<Firma> PobierzNajlepszeFirmy();

        IEnumerable<Firma> Pobierz10NajlepszychFirmWedlogPaczki(int paczka);

        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmy(int id_firma);
        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmy(Firma firma);

        IEnumerable<Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(int id_firmy, int paczka);
        IEnumerable<Logika.Komentarz> PobierzNajlepszeKomentarzeFirmyWedlogPaczki(Logika.Firma firma, int paczka);


        Firma ZarejestrujFirmeUzytkownika(string id_uzytkownik, Firma firma);
        Firma ZarejestrujFirmeUzytkownika(Uzytkownik uzytkownik, Firma firma);

        Ocena WystawOceneFirmie(string id_uzytkownik, int id_firma, Ocena ocena);
        Ocena WystawOceneFirmie(Uzytkownik uzytkownik, Firma firma, Ocena ocena);

        Komentarz WystawKomentarzFirmie(string id_uzytkownik, int id_firma, Komentarz komentarz);
        Komentarz WystawKomentarzFirmie(Uzytkownik uzytkownik, Firma firma, Komentarz komentarz);

        Ocena ObliczSredniaOceneFirmy(Firma firma);
        Ocena ObliczSredniaOceneFirmy(int id_firma);

        Firma PobierzFirmePoId(int id_firmy);

        Uzytkownik PobierzUzytkownikaPoId(string id_uzytkownika);

        double ObliczRankingFirmy(int id_firma);
        double ObliczRankingFirmy(Firma firma);

        bool UzytkownikMozeStworzycFirme(string id_uzytkownika);
        bool UzytkownikMozeStworzycFirme(Uzytkownik uzytkownik);
    }
}
