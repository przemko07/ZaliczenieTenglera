using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace gui.ViewModels
{
    public class PojedynczaFirmaVM : FirmaVM
    {
        public PojedynczaFirmaVM(Firma firma, Ocena srednia_ocena)
            : base (firma, srednia_ocena)
        {
        }
    }
}