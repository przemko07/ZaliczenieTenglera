using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class NowaFirmaVM
    {
        public string miasto { get; set; }

        public string ulica { get; set; }

        public string numer_budynku { get; set; }

        public string numer_lokalu { get; set; }

        public string mail { get; set; }

        public string numer_komurkowy { get; set; }

        public string nazwa { get; set; }

        public Firma SwtorzFirme()
        {
            Firma firma = new Firma
            {
                nazwa = nazwa,
                adres = new Adres
                {
                    ulica = ulica,
                    numer_budynku = numer_budynku,
                    numer_lokalu = numer_lokalu,
                },
                kontakt = new Kontakt
                {
                    mail = mail,
                    numer_komurkowy = numer_komurkowy
                },
            };

            return firma;
        }
    }
}