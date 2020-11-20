using AgencijaZaNekretnineMVC.Models;
using AgencijaZaNekretnineMVC.Models.Interfaces;
using AgencijaZaNekretnineMVC.Models.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace AgencijaZaNekretnineMVC.Controllers
{
    public class NekretninaController : Controller
    {
        private INekretninaRepository nekretninaRepository;

        public NekretninaController()
        {
            nekretninaRepository = new NekretninaRepository();
        }
        // GET: Nekretnina
        public ActionResult UnosNekretnine()
        {
             if (Session["osobaID"] == null)
             {
                 return RedirectToAction("Login", "Osoba");
             }
             else
             {
                 return View();
             }
            //return View();

        }
        [HttpPost]
        public ActionResult UnosNekretnine(NekretninaBO nekretnina)
        {
            var files = nekretnina.Files;
            nekretnina.Vlasnik.OsobaId =(int)Session["osobaId"];
            nekretninaRepository.AddNekretnina(nekretnina, files);
            ViewBag.SuccessMessage = "Uspesno ste uneli nekretninu!";
            return View(nekretnina);
        }
        public ActionResult PrikazSvihNekretnina()
        {
            List<NekretninaBO> nekretnine = nekretninaRepository.GetAllNekretnine().ToList();
            var result = new PrikazSvihNekretnina();
            result.Nekretnine = new List<NekretninaBO>(nekretnine);
            return View(result);
        }
        [HttpPost]
        public ActionResult PrikazSvihNekretnina(NekretninaKarateristikeFilter filter)
        { 

            List<NekretninaBO> nekretnine = nekretninaRepository.GetNekretnineByKarakteristke(filter).ToList();
            var result = new PrikazSvihNekretnina();
            result.Nekretnine = new List<NekretninaBO>(nekretnine);
            result.Filter = filter;
            return View(result);
        }
        public ActionResult IzmenaNekretnine()
        {
            if (Session["osobaId"] == null)
            {
                return RedirectToAction("Login", "Osoba");
            }
            else
            {
                var id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);
                Session["NekretninaId"] = id.ToString();
                var nekretnina = nekretninaRepository.GetSingle(id);
                return View(nekretnina);
            }
            
        }

        [HttpPost]
        public ActionResult IzmenaNekretnine(NekretninaBO nekretnina)
        {
            var id = Session["NekretninaId"];
            nekretnina.NekretninaID = Convert.ToInt32(id);

            nekretninaRepository.UpdateNekretnina(nekretnina, new List<HttpPostedFileBase>());


            return View();
        }
    }
}