using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace gui.ViewModels
{
    public abstract class FirmaVM
    {
        public int id_firmy { get; set; }
        public string nazwa_firmy { get; set; }
        public string adres_firmy { get; set; }
        public string email_firmy { get; set; }
        public string telefon_firmy { get; set; }


        public FirmaVM(Firma firma)
        {
            try
            {
                id_firmy = firma.id;
                nazwa_firmy = firma.nazwa;
                adres_firmy =
                    firma.adres.miasto + " " +
                    firma.adres.ulica + " " +
                    firma.adres.numer_budynku + "/" +
                    firma.adres.numer_lokalu;
                email_firmy = firma.kontakt.mail;
                telefon_firmy = firma.kontakt.numer_komurkowy;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public FirmaVM()
        {

        }
    }
}