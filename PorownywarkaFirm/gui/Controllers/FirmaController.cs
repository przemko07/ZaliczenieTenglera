﻿using Aplikacja;
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
using System.Diagnostics;

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
            Firma firma = aplikacja.PobierzNajlepszeFirmy().FirstOrDefault();

            Ocena srednia_ocen = Ocena.Null;
            try
            {
                srednia_ocen = aplikacja.ObliczSredniaOceneFirmy(firma);
            }
            catch (BrakOcen e)
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

        public ActionResult SzczegolyFirmy(int id_firmy = 0)
        {
            Firma firma = Firma.Null;
            try
            {
                firma = aplikacja.PobierzFirmePoId(id_firmy);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            Ocena ocena = Ocena.Null;
            try
            {
                ocena = aplikacja.ObliczSredniaOceneFirmy(firma);
            }
            catch (BrakOcen e)
            {
                ocena = Ocena.Null;
            }
            IEnumerable<Komentarz> komentarze = null;
            try
            {
                komentarze = aplikacja.PobierzNajlepszeKomentarzeFirmy(firma);
            }
            catch (Exception e)
            {
                komentarze = new Komentarz[0];
            }

            return View(new SczegolowaFirmaVM(firma, ocena, komentarze));
        }

        [Authorize]
        public void OcenKomentarzPozytywnie(int id_komentarza = 0)
        {
            try
            {
                aplikacja.OcenienieKomentarzaPozytywnie(id_komentarza, User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [Authorize]
        public void OcenKomentarzNegatywnie(int id_komentarza = 0)
        {
            try
            {
                aplikacja.OcenienieKomentarzaNegatywnie(id_komentarza, User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        [Authorize]
        public ActionResult OcenFirme(int id_firmy = 0)
        {
            Firma firma = aplikacja.PobierzFirmePoId(id_firmy); firma.id = 90;
            Ocena ocena = aplikacja.ObliczSredniaOceneFirmy(firma);

            return View(new OcenaFirmyVM(firma, ocena));
        }

        [HttpPost]
        [Authorize]
        public ActionResult OcenFirme(OcenaFirmyVM vm)
        {
            Ocena ocena = vm.StworzOcene();

            aplikacja.WystawOceneFirmie(User.Identity.GetUserId(), vm.id_firmy, ocena);

            return RedirectToAction("SzczegolyFirmy", new { id_firmy = vm.id_firmy });
        }

        [HttpPost]
        [Authorize]
        public ActionResult DodajKomentarz(int id_firmy = 0)
        {
            Komentarz komentarz = new Komentarz
            {
                tresc = Request["tresc"] as string,
            };
            try
            {
                aplikacja.WystawKomentarzFirmie(User.Identity.GetUserId(), id_firmy, komentarz);
            }
            catch (BrakFirmy e)
            {
                Debug.WriteLine("Brak firmy:" + id_firmy);
            }
            catch (BrakUzytkownika e)
            {
                Debug.WriteLine("Brak użytkownika:" + User.Identity.GetUserId());
            }
            catch (UzytkownikKomentujeWlasnaFirme e)
            {
                Debug.WriteLine("Uzytkownik ocenia wlasna firme:" + id_firmy);
            }

            return RedirectToAction("SzczegolyFirmy", new { id_firmy = id_firmy });
        }

        [Authorize]
        public ActionResult StworzFirme()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult StworzFirme(NowaFirmaVM vm)
        {
            Firma firma = vm.SwtorzFirme();

            firma = aplikacja.ZarejestrujFirmeUzytkownika(User.Identity.GetUserId(), firma);

            return RedirectToAction("SzczegolyFirmy", new { id_firmy = firma.id });
        }
    }
}