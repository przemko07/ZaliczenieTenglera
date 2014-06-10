using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace gui.ViewModels
{
    public class FirmaZSzczegolamiVM : FirmaZSredniaOcenaVM
    {
        public IEnumerable<KomentarzVM> komentarze { get; set; }
        public FirmaZSzczegolamiVM(Firma firma, Ocena srednia_ocena, IEnumerable<Komentarz> komentarze)
            : base(firma, srednia_ocena)
        {
            this.komentarze = komentarze.Select(
                n => new KomentarzVM(n));
        }

    }
}