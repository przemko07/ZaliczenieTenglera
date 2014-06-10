using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class KomentarzVM
    {
        public int id_firmy { get; set; }
        public int id { get; set; }
        public string wlasciciel { get; set; }
        public string tresc { get; set; }
        public int ocena { get; set; }
        public KomentarzVM()
        {

        }
        public KomentarzVM(Komentarz komentarz)
        {
            try
            {
                id_firmy = komentarz.firma.id;
            }
            catch { }
            id = komentarz.id;
            try
            {
                wlasciciel = komentarz.wlasciciel.UserName;
            }
            catch { }
            tresc = komentarz.tresc;
            ocena = komentarz.ocena;
        }
    }
}