using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace gui.ViewModels
{
    public class FirmaZSredniaOcenaVM : FirmaVM
    {
        public Chart wykres { get; set; }
        public FirmaZSredniaOcenaVM(Firma firma, Ocena srednia_ocena)
            : base (firma)
        {
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