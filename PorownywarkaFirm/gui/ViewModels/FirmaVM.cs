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
        public Chart wykres { get; set; }
        public FirmaVM(Firma firma, Ocena srednia_ocena)
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

            try
            {
                wykres = new Chart(400, 250)
                .AddTitle("srednia ocen")
                .AddSeries(name: "wyglad firmy", yValues: new[] { srednia_ocena.wyglad_firmy })
                .AddSeries(name: "poziom obslugi", yValues: new[] { srednia_ocena.poziom_obslugi })
                .AddSeries(name: "czas świadczenia usług", yValues: new[] { srednia_ocena.czas_swiadczenia_uslug })
                .AddSeries(name: "lokalizacja", yValues: new[] { srednia_ocena.lokalizacja })
                .AddSeries(name: "poziom świadczonej usługi", yValues: new[] { srednia_ocena.poziom_swiadczonej_uslugi })
                .AddSeries(name: "atmosfera", yValues: new[] { srednia_ocena.atmosera })
                .AddSeries(name: "zarobki", yValues: new[] { srednia_ocena.zarobki })
                .AddSeries(name: "kontakt z przełożonym", yValues: new[] { srednia_ocena.kontakt_z_przelozonymi })
                .AddSeries(name: "wyposażenie", yValues: new[] { srednia_ocena.wyposazenie });

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}