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

            Ocena srednia_ocen = Ocena.Null;
            try
            {
                srednia_ocen = aplikacja.ObliczSredniaOceneFirmy(firma);
            }
            catch(BrakOceny e)
            {
                srednia_ocen = Ocena.Null;
            }
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


        public ActionResult OcenKomentarzPozytywnie(int id = 0)
        {
            aplikacja.OcenienieKomentarzaPozytywnie(id, User.Identity.GetUserId());

            return View();
        }


        public ActionResult OcenKomentarzNegatywnie(int id = 0)
        {
            aplikacja.OcenienieKomentarzaNegatywnie(id, User.Identity.GetUserId());

            return View();
        }

        public ActionResult OcenFirme(int id = 0)
        {
            Firma firma = aplikacja.PobierzFirmePoId(id); firma.id = 90;
            Ocena ocena = aplikacja.ObliczSredniaOceneFirmy(firma);

            return View(new OcenaFirmyVM(firma, ocena));
        }

        [HttpPost]
        public ActionResult OcenFirme(OcenaFirmyVM vm)
        {
            Ocena ocena = vm.StworzOcene();

            aplikacja.WystawOceneFirmie(User.Identity.GetUserId(), vm.id_firmy, ocena);

            return RedirectToAction("SzczegolyFirmy", vm.id_firmy);
        }

        [HttpPost]
        public ActionResult DodajKomentarz(int id_firma, string tresc)
        {
            Komentarz komentarz = new Komentarz
            {
                tresc = tresc,
            };

            aplikacja.WystawKomentarzFirmie(User.Identity.GetUserId(), id_firma, komentarz);

            return View();
        }

        public ActionResult StworzFirme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StworzFirme(NowaFirmaVM vm)
        {
            Firma firma = vm.SwtorzFirme();

            aplikacja.ZarejestrujFirmeUzytkownika(User.Identity.GetUserId(), firma);

            return RedirectToAction("SzczegolyFirmy", firma.id);
        }
    }
}