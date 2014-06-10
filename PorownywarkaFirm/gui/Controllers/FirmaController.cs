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
using System.Diagnostics;
using gui.Models;
using gui.Hubs;
using System.IO;

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
            return View(new FirmaZSredniaOcenaVM(firma, srednia_ocen));
        }

        public ActionResult RankingFirm()
        {
            IEnumerable<Firma> firmy = aplikacja.Pobierz10NajlepszychFirmWedlogPaczki(0);

            IEnumerable<FirmaZRankingiemVM> vms = firmy.Select(
                n =>
                {
                    try
                    {
                        return new FirmaZRankingiemVM(n, aplikacja.ObliczRankingFirmy(n));
                    }
                    catch (BrakOcen e)
                    {
                        return new FirmaZRankingiemVM(n, "?");
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return new FirmaZRankingiemVM(n, "?");
                    }
                });

            return View(new PaczkaFirmVM(0, vms));
        }
        public ActionResult PobierzRankingFirm(int paczka)
        {
            IEnumerable<Firma> firmy = aplikacja.Pobierz10NajlepszychFirmWedlogPaczki(paczka);

            IEnumerable<FirmaZRankingiemVM> vms = firmy.Select(
                n =>
                {
                    try
                    {
                        return new FirmaZRankingiemVM(n, aplikacja.ObliczRankingFirmy(n));
                    }
                    catch (BrakOcen e)
                    {
                        return new FirmaZRankingiemVM(n, "?");
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return new FirmaZRankingiemVM(n, "?");
                    }
                });

            return PartialView("_PobierzRankingFirm", new PaczkaFirmVM(paczka, vms));
        }

        public ActionResult PobierzNajlepszeKomentarze(int id_firma, int paczka)
        {
            IEnumerable<Komentarz> komentarze = aplikacja.PobierzNajlepszeKomentarzeFirmyWedlogPaczki(id_firma, paczka);
            return PartialView("_KomentarzeList", komentarze.Select(n => new KomentarzVM(n)));
        }

        public ActionResult SzczegolyFirmy(int id_firmy = 0)
        {
            Firma firma = Firma.Null;
            try
            {
                firma = aplikacja.PobierzFirmePoId(id_firmy);
            }
            catch (BrakFirmy)
            {
                return RedirectToAction("index");
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
                komentarze = aplikacja.PobierzNajlepszeKomentarzeFirmyWedlogPaczki(firma, 0);
            }
            catch (Exception e)
            {
                komentarze = new Komentarz[0];
            }

            return View(new FirmaZSzczegolamiVM(firma, ocena, komentarze));
        }

        [Authorize]
        public int OcenKomentarzPozytywnie(int id_komentarza = 0)
        {
            try
            {
                aplikacja.OcenienieKomentarzaPozytywnie(id_komentarza, User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return aplikacja.PobierzOceneKomentarza(id_komentarza);
        }

        [Authorize]
        public int OcenKomentarzNegatywnie(int id_komentarza = 0)
        {
            try
            {
                aplikacja.OcenienieKomentarzaNegatywnie(id_komentarza, User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return aplikacja.PobierzOceneKomentarza(id_komentarza);
        }

        [Authorize]
        public ActionResult OcenFirme(int id_firmy = 0)
        {
            Firma firma = aplikacja.PobierzFirmePoId(id_firmy);

            return View(new OcenaFirmyVM(firma));
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
            if (aplikacja.UzytkownikMozeStworzycFirme(User.Identity.GetUserId()))
            {
                return View();
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult StworzFirme(NowaFirmaVM vm, HttpPostedFileBase uploadFile)
        {
            Firma firma = vm.SwtorzFirme(Server, uploadFile);

            firma = aplikacja.ZarejestrujFirmeUzytkownika(User.Identity.GetUserId(), firma);

            return RedirectToAction("SzczegolyFirmy", new { id_firmy = firma.id });
        }

        public MvcHtmlString CzyFirmaJest()
        {
            Uzytkownik uzytkownik = aplikacja.PobierzUzytkownikaPoId(User.Identity.GetUserId());
            if (uzytkownik == null)
            {
                return new MvcHtmlString("false");
            }
            if (uzytkownik.firma != null)
            {
                return new MvcHtmlString("true");
            }
            else
            {
                return new MvcHtmlString("false");
            }
        }

        [Authorize]
        public ActionResult EdytujFirme()
        {
            Uzytkownik uzytkownik = aplikacja.PobierzUzytkownikaPoId(User.Identity.GetUserId());

            if (uzytkownik.firma != null)
            {
                return View(new EdytujFirmaVM(uzytkownik.firma));
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult EdytujFirme(EdytujFirmaVM vm, HttpPostedFileBase uploadFile)
        {
            Firma firma = vm.SwtorzFirme(Server, uploadFile);

            firma = aplikacja.ZarejestrujFirmeUzytkownika(User.Identity.GetUserId(), firma);

            return RedirectToAction("SzczegolyFirmy", new { id_firmy = firma.id });
        }
    }
}