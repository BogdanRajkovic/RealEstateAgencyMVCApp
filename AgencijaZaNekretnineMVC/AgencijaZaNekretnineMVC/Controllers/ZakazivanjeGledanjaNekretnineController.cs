using AgencijaZaNekretnineMVC.Models;
using AgencijaZaNekretnineMVC.Models.Interfaces;
using AgencijaZaNekretnineMVC.Models.RepositoryEF;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace AgencijaZaNekretnineMVC.Controllers
{
    public class ZakazivanjeGledanjaNekretnineController : Controller
    {
        // GET: ZakazivanjeGledanjaNekretnine
        private IZakazivanjeGledanjaNekretnineRepository zakazivanjeNekretnine;
        public ZakazivanjeGledanjaNekretnineController()
        {
            zakazivanjeNekretnine = new ZakazivanjeGledanjaNekretnineRepository();
        }
        public ActionResult ZakazivanjeGledanjaNekretnine()
        {
            if (Session["osobaID"] == null)
            {
                return RedirectToAction("Login", "Osoba");
            }
            else
            {
                var id = Url.RequestContext.RouteData.Values["id"];
                Session["NekretninaId"] = id.ToString();
                return View();
            }
        }
        [HttpPost]
        public ActionResult SacuvajZakazivanje(DateTime DatumVreme)
        {
            var nekretninaID = Convert.ToInt32( Session["NekretninaId"]);
            var osobaId = Convert.ToInt32( Session["osobaID"]);
            //int idNekre = Session["nekretninaId"];
            //var id = Url.RequestContext.RouteData.Values["id"];
            zakazivanjeNekretnine.AddZakazivanje(DatumVreme, nekretninaID, osobaId);
            /*var url = Url.RequestContext.RouteData.Values["id"];*/
            return RedirectToAction("GetAllZakazivanjaByOsoba", "ZakazivanjeGledanjaNekretnine");
        }
        public ActionResult GetAllZakazivanjaByOsoba()
        {
            if (Session["osobaId"] == null)
            {
                return RedirectToAction("Login", "Osoba");
            }
            else
            {
                var id = Convert.ToInt32(Session["osobaId"]);
                IEnumerable<ZakazivanjeGledanjaNekretnineBO> zakazivanje = zakazivanjeNekretnine.GetAllZakazivanjaByOsoba(id);
                return View(zakazivanje);
            }
                
            
        }
    }
        
}