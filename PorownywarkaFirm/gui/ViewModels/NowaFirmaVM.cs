using Aplikacja;
using gui.ViewModels;
using IAplikacja;
using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using gui.Models;
using gui.Hubs;
using System.IO;

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

        public string zdjecie { get; set; }

        internal Firma SwtorzFirme(HttpServerUtilityBase server, HttpPostedFileBase uploadFile)
        {
            string url = string.Empty;
            if (uploadFile != null && uploadFile.FileName != string.Empty)
            {
                url = Path.Combine(server.MapPath("~/Images/firmy"), uploadFile.FileName);
                uploadFile.SaveAs(url);
                url = Path.Combine("../Images/firmy", uploadFile.FileName);
            }

            Firma firma = new Firma
            {
                nazwa = nazwa,
                zdjecie = url,
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