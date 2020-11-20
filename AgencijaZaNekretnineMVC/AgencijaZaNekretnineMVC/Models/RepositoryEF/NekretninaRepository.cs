using AgencijaZaNekretnineMVC.Models.Extensions;
using AgencijaZaNekretnineMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models.RepositoryEF
{
    public class NekretninaRepository : INekretninaRepository
    {
        private AgencijaZaNekretnineEntities agencijaZaNekretnineEntities = new AgencijaZaNekretnineEntities();

        /*Funckija za dodvanje podataka o nekretnini sa html forme i njihov upis u bazu*/
        public void AddNekretnina(NekretninaBO nekretnina, List<HttpPostedFileBase> files)
        {
            var slike = new List<Slika>();

            foreach (var item in files)
            {
                slike.Add(new Slika
                {
                    Putanja = item.FileName
                });
            }

            var result = new NekretninaModel
            {
                Adresa = nekretnina.Adresa,
                Opstina = nekretnina.Opstina,
                Spratnost = nekretnina.Spratnost,
                Povrsina = nekretnina.Povrsina,
                Cena = (decimal)nekretnina.Cena,
                Namestenost = nekretnina.Namestenost,
                VrstaNekretnine = nekretnina.VrstaNekretnine,
                Struktura = nekretnina.Struktura,
                Stanje = nekretnina.Stanje,
                Sprat = nekretnina.Sprat,
                DodatneKarakteristike = nekretnina.DodatneKarakteristike,
                Napomena = nekretnina.Napomena,
                Slike = slike,
                VlasnikID = (int)HttpContext.Current.Session["osobaId"]
            };

            agencijaZaNekretnineEntities.NekretninaModels.Add(result);
            agencijaZaNekretnineEntities.SaveChanges();

            var directoryName = $"Nekretnina-{result.NekretninaID}";
            var directoryRelativePath = System.Web.Hosting.HostingEnvironment.MapPath($"~/~/Slike");
            var path = Path.Combine(directoryRelativePath, directoryName);

            Directory.CreateDirectory(path);

            foreach (var item in files)
            {
                var imageFullPath = Path.Combine(path, item.FileName);
                item.SaveAs(imageFullPath);
            }
        }
        /*Povlaci sve nekretnine iz baze podataka*/
        public IEnumerable<NekretninaBO> GetAllNekretnine()
        {
            List<NekretninaBO> nekretnine = new List<NekretninaBO>();
            foreach (NekretninaModel nekretninaModel in agencijaZaNekretnineEntities.NekretninaModels)
            {
                NekretninaBO nekretninaBO = new NekretninaBO()
                {
                    NekretninaID = nekretninaModel.NekretninaID,
                    Adresa = nekretninaModel.Adresa,
                    Opstina = nekretninaModel.Opstina,
                    Spratnost = (int)nekretninaModel.Spratnost,
                    Povrsina = (float)nekretninaModel.Povrsina,
                    Cena = (double)nekretninaModel.Cena,
                    Namestenost = nekretninaModel.Namestenost,
                    VrstaNekretnine = nekretninaModel.VrstaNekretnine,
                    Struktura = nekretninaModel.Struktura,
                    Stanje = nekretninaModel.Stanje,
                    Sprat = (int)nekretninaModel.Sprat,
                    DodatneKarakteristike = nekretninaModel.DodatneKarakteristike,
                    Napomena = nekretninaModel.Napomena,
                    Slike = new List<Slika>(nekretninaModel.Slike),
                    Vlasnik = new OsobaBO()
                    {
                        OsobaId = (int)nekretninaModel.VlasnikID
                    }
                };
                nekretnine.Add(nekretninaBO);
            }
            return nekretnine;
        }
        /*Povlaci nekretnine iz baze podataka prema unetim karakteristikama*/
        public IEnumerable<NekretninaBO> GetNekretnineByKarakteristke(NekretninaKarateristikeFilter filter)
        {
            List<NekretninaBO> nekretnine = new List<NekretninaBO>();
            var nekretnineDb = agencijaZaNekretnineEntities.NekretninaModels
                .Where(n =>
                    (filter.Opstina == null || string.Equals(n.Opstina, filter.Opstina)) &&
                    (filter.VrstaNekretnine == null || string.Equals(n.VrstaNekretnine, filter.VrstaNekretnine))&&
                    (filter.Povrsina == null || n.Povrsina <= filter.Povrsina) &&
                    (filter.CenaNajniza == null || n.Cena >= filter.CenaNajniza)&&
                    (filter.CenaNajvisa == null || n.Cena <= filter.CenaNajvisa)
                ).ToList();

            foreach (NekretninaModel nekretninaModel in nekretnineDb)
            {
                NekretninaBO nekretninaBO = new NekretninaBO()
                {
                    NekretninaID = nekretninaModel.NekretninaID,
                    Adresa = nekretninaModel.Adresa,
                    Opstina = nekretninaModel.Opstina,
                    Spratnost = (int)nekretninaModel.Spratnost,
                    Povrsina = (float)nekretninaModel.Povrsina,
                    Cena = (double)nekretninaModel.Cena,
                    Namestenost = nekretninaModel.Namestenost,
                    VrstaNekretnine = nekretninaModel.VrstaNekretnine,
                    Struktura = nekretninaModel.Struktura,
                    Stanje = nekretninaModel.Stanje,
                    Sprat = (int)nekretninaModel.Sprat,
                    DodatneKarakteristike = nekretninaModel.DodatneKarakteristike,
                    Napomena = nekretninaModel.Napomena,
                    Slike = new List<Slika>(nekretninaModel.Slike),
                    Vlasnik = new OsobaBO()
                    {
                        OsobaId = (int)nekretninaModel.VlasnikID
                    }
                };
                nekretnine.Add(nekretninaBO);
            }
            return nekretnine.ToList();
        }

        public NekretninaBO GetSingle(int id)
        {
            var nekretninaModel = agencijaZaNekretnineEntities.NekretninaModels.SingleOrDefault(n=> n.NekretninaID== id);
            NekretninaBO result = new NekretninaBO()
            {
                NekretninaID = nekretninaModel.NekretninaID,
                Adresa = nekretninaModel.Adresa,
                Opstina = nekretninaModel.Opstina,
                Spratnost = (int)nekretninaModel.Spratnost,
                Povrsina = (float)nekretninaModel.Povrsina,
                Cena = (double)nekretninaModel.Cena,
                Namestenost = nekretninaModel.Namestenost,
                VrstaNekretnine = nekretninaModel.VrstaNekretnine,
                Struktura = nekretninaModel.Struktura,
                Stanje = nekretninaModel.Stanje,
                Sprat = (int)nekretninaModel.Sprat,
                DodatneKarakteristike = nekretninaModel.DodatneKarakteristike,
                Napomena = nekretninaModel.Napomena,
                Slike = new List<Slika>(nekretninaModel.Slike),
                Vlasnik = new OsobaBO()
                {
                    OsobaId = (int)nekretninaModel.VlasnikID
                }
            };
            return result;
        }

        public void UpdateNekretnina(NekretninaBO nekretnina, List<HttpPostedFileBase> files)
        {
            var nekretninaDb = agencijaZaNekretnineEntities.NekretninaModels.SingleOrDefault(n=>n.NekretninaID==nekretnina.NekretninaID);

            if (!string.Equals(nekretninaDb.Adresa, nekretnina.Adresa))
            {
                nekretninaDb.Adresa = nekretnina.Adresa;
            }

            if (!string.Equals(nekretninaDb.Opstina, nekretnina.Opstina))
            {
                nekretninaDb.Opstina = nekretnina.Opstina;
            }

            if (nekretninaDb.Spratnost != nekretnina.Spratnost)
            {
                nekretninaDb.Spratnost = nekretnina.Spratnost;
            }

            if (nekretninaDb.Povrsina != nekretnina.Povrsina)
            {
                nekretninaDb.Povrsina = nekretnina.Povrsina;
            }

            if (nekretninaDb.Cena != (decimal)nekretnina.Cena)
            {
                nekretninaDb.Cena = (decimal)nekretnina.Cena;
            }

            if (!string.Equals(nekretninaDb.VrstaNekretnine, nekretnina.VrstaNekretnine))
            {
                nekretninaDb.VrstaNekretnine = nekretnina.VrstaNekretnine;
            }

            if (!string.Equals(nekretninaDb.Struktura, nekretnina.Struktura))
            {
                nekretninaDb.Struktura = nekretnina.Struktura;
            }

            if (!string.Equals(nekretninaDb.Stanje, nekretnina.Stanje))
            {
                nekretninaDb.Stanje = nekretnina.Stanje;
            }
            
            if (nekretninaDb.Sprat != nekretnina.Sprat)
            {
                nekretninaDb.Sprat = nekretnina.Sprat;
            }
            
            if (!string.Equals(nekretninaDb.DodatneKarakteristike, nekretnina.DodatneKarakteristike))
            {
                nekretninaDb.DodatneKarakteristike = nekretnina.DodatneKarakteristike;
            }

            if (!string.Equals(nekretninaDb.Napomena, nekretnina.Napomena))
            {
                nekretninaDb.Napomena = nekretnina.Napomena;
            }

            agencijaZaNekretnineEntities.SaveChanges();
        }


    }
}