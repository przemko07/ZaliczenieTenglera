using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class EdytujFirmaVM
        : NowaFirmaVM
    {
        public EdytujFirmaVM()
        {
        }
        public EdytujFirmaVM(Firma firma)
        {
            this.nazwa = firma.nazwa;
            this.zdjecie = firma.zdjecie;

            if (firma.adres != null)
            {
                this.miasto = firma.adres.miasto;
                this.ulica = firma.adres.ulica;
                this.numer_budynku = firma.adres.numer_budynku;
                this.numer_lokalu = firma.adres.numer_lokalu;
            }
            if (firma.kontakt != null)
            {
                this.numer_komurkowy = firma.kontakt.numer_komurkowy;
                this.mail = firma.kontakt.mail;
            }
        }
    }
}