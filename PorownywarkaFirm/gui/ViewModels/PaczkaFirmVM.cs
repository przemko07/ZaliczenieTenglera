using IAplikacja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gui.ViewModels
{
    public class PaczkaFirmVM
    {
        public int aktualna { get; set; }

        public IEnumerable<FirmaZRankingiemVM> firmy { get; set; }

        public PaczkaFirmVM(int paczka, IEnumerable<FirmaZRankingiemVM> firmy)
        {
            aktualna = paczka;
            this.firmy = firmy;
        }
    }
}