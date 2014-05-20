using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace gui.ViewModels
{
    public class SczegolowaFirmaVM : FirmaVM
    {
        public IEnumerable<Tuple<int, string, int>> komentarze { get; set; } // id | tresc | like
        public SczegolowaFirmaVM(Firma firma, Ocena srednia_ocena, IEnumerable<Komentarz> komentarze)
            : base(firma, srednia_ocena)
        {
            this.komentarze = komentarze.Select(
                n => new Tuple<int, string, int>(n.id, n.tresc, n.ocena));
        }

    }
}