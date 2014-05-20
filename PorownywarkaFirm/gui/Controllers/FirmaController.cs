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

        public ActionResult RankingFirm(int paczka = 0)
        {
            IEnumerable<Firma> firmy = aplikacja.Pobierz10NajlepszychFirmWedlogPaczki(paczka);

            IEnumerable<PojedynczaFirmaVM> vm = firmy.Select(
                n => new PojedynczaFirmaVM(n, aplikacja.ObliczSredniaOceneFirmy(n)));

            return View(vm);
        }

        public ActionResult SzczegolyFirmy(int id = 0)
        {
            Firma firma = aplikacja.PobierzFirmePoId(id);
            Ocena ocena = aplikacja.ObliczSredniaOceneFirmy(firma);

            IEnumerable<Komentarz> komentarze = aplikacja.PobierzNajlepszeKomentarzeFirmy(firma);

            return View(new SczegolowaFirmaVM(firma, ocena, komentarze));
        }

        [HttpPost]
        public ActionResult OcenKomentarzPozytywnie(int id = -1)
        {
            aplikacja.OcenienieKomentarzaPozytywnie(id, User.Identity.GetUserId());

            return View();
        }

        [HttpPost]
        public ActionResult OcenKomentarzNegatywnie(int id = -1)
        {
            aplikacja.OcenienieKomentarzaNegatywnie(id, User.Identity.GetUserId());

            return View();
        }
    }
}