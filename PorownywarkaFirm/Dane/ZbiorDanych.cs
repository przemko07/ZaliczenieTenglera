using IDane;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class ZbiorDanych : DbContext, IZbiorDanych
    {
        #region pomocnik
        public IZbiorAdresow Adresy { get { return this as IZbiorAdresow; } }
        public IZbiorFirm Firmy { get { return this as IZbiorFirm; } }
        public IZbiorKomentarzy Komentarze { get { return this as IZbiorKomentarzy; } }
        public IZbiorKontaktow Kontakty { get { return this as IZbiorKontaktow; } }
        public IZbiorOcen Oceny { get { return this as IZbiorOcen; } }
        public IZbiorUzytkownikow Uzytkownicy { get { return this as IZbiorUzytkownikow; } }
        #endregion

        #region DBContext
        public object DBContext
        {
            get { return this; }
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorAdresow
        public void Zapisz(Logika.Adres obj)
        {
            throw new NotImplementedException();
        }

        public void Popraw(Logika.Adres obj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Logika.Adres obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Logika.Adres> IZbiorAdresow.Wczytaj()
        {
            throw new NotImplementedException();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorFirm
        public void Zapisz(Logika.Firma obj)
        {
            throw new NotImplementedException();
        }

        public void Popraw(Logika.Firma obj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Logika.Firma obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Logika.Firma> IZbiorFirm.Wczytaj()
        {
            throw new NotImplementedException();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorKomentarzy

        public void Zapisz(Logika.Komentarz obj)
        {
            throw new NotImplementedException();
        }

        public void Popraw(Logika.Komentarz obj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Logika.Komentarz obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Logika.Komentarz> IZbiorKomentarzy.Wczytaj()
        {
            throw new NotImplementedException();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorKontaktow
        public void Zapisz(Logika.Kontakt obj)
        {
            throw new NotImplementedException();
        }

        public void Popraw(Logika.Kontakt obj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Logika.Kontakt obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Logika.Kontakt> IZbiorKontaktow.Wczytaj()
        {
            throw new NotImplementedException();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorOcen
        public void Zapisz(Logika.Ocena obj)
        {
            throw new NotImplementedException();
        }

        public void Popraw(Logika.Ocena obj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Logika.Ocena obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Logika.Ocena> IZbiorOcen.Wczytaj()
        {
            throw new NotImplementedException();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->Uzytkownikow
        public void Zapisz(Logika.Uzytkownik obj)
        {
            throw new NotImplementedException();
        }

        public void Popraw(Logika.Uzytkownik obj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Logika.Uzytkownik obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Logika.Uzytkownik> IZbiorUzytkownikow.Wczytaj()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
