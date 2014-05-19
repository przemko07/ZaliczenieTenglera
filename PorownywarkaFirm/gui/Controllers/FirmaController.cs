using Aplikacja;
using gui.ViewModels;
using IAplikacja;
using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gui.Controllers
{
    public class FirmaController : Controller
    {
        //
        // GET: /Firma/
        IZbiorFunkcji aplikacja { get; set; }
        public FirmaController(IZbiorFunkcji aplikacja)
        {
            this.aplikacja = aplikacja;
        }

        public ActionResult Index()
        {
            Firma firma = aplikacja.PobierzNajlepszeFirmy().First();
            Ocena srednia_ocen = aplikacja.ObliczSredniaOceneFirmy(firma);

            return View(new NajlepszaFirmaVM(firma, srednia_ocen));
        }
	}
}