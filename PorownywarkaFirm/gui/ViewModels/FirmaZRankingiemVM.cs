using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class FirmaZRankingiemVM : FirmaVM
    {
        public string ranking { get; set; }

        public FirmaZRankingiemVM(Firma firma, double ranking)
            : base(firma)
        {
            this.ranking = ranking.ToString("{0.00}");
        }
        public FirmaZRankingiemVM(Firma firma, string ranking)
            : base(firma)
        {
            this.ranking = ranking;
        }

    }
}