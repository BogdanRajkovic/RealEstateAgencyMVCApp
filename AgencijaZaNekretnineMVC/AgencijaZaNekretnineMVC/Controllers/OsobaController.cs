using AgencijaZaNekretnineMVC.Models;
using AgencijaZaNekretnineMVC.Models.Interfaces;
using AgencijaZaNekretnineMVC.Models.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencijaZaNekretnineMVC.Controllers
{
    public class OsobaController : Controller
    {
        private IOsobaRepository osobaRepository;
        // GET: Osoba
        public OsobaController()
        {
            osobaRepository = new OsobaRepository();
            
        }
        public ActionResult Registracija()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registracija(OsobaBO osoba)
        {
            AgencijaZaNekretnineEntities agencijaZaNekretnineEntities = new AgencijaZaNekretnineEntities();
            if (agencijaZaNekretnineEntities.OsobaModels.Any(o => o.KorisnickoIme == osoba.KorisnickoIme))
            {
                ViewBag.DuplicateMessage = "Korisnicko ime vec postoji";
                return View("Registracija", osoba);
            }
            else
            {
                osobaRepository.AddOsoba(osoba);
            }
            ViewBag.SuccessMessage = "Uspesno ste se registrovali!";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(OsobaBO osoba)
        {
            AgencijaZaNekretnineEntities agencijaZaNekretnineEntities = new AgencijaZaNekretnineEntities();
            var korisnikDetalji = agencijaZaNekretnineEntities.OsobaModels.Where(o => o.KorisnickoIme == osoba.KorisnickoIme && o.Sifra == osoba.Sifra).FirstOrDefault();
            //var korisnikSifraLogin = agencijaZaNekretnineEntities.OsobaModels.Where(o => o.Sifra == osoba.Sifra).FirstOrDefault();
            if (korisnikDetalji == null)
            {
                ViewBag.DuplicateMessage = "Netacno korisnicko ime i sifra ";
                return View(osoba);
            }
            else
            {
                Session["osobaId"] = korisnikDetalji.OsobaID;
                Session["korisnickoIme"] = korisnikDetalji.KorisnickoIme;
                Session["IsAdmin"] = korisnikDetalji.IsAdmin;
                return RedirectToAction("PrikazSvihNekretnina", "Nekretnina");
                
            }
        }
        public ActionResult Logout()
        {
            
            return RedirectToAction("Login","Osoba");
        }
    }
}