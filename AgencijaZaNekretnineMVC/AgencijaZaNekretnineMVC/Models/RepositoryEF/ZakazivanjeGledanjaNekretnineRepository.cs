using AgencijaZaNekretnineMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models.RepositoryEF
{
    public class ZakazivanjeGledanjaNekretnineRepository : IZakazivanjeGledanjaNekretnineRepository
    {
        private AgencijaZaNekretnineEntities agencijaZaNekretnineEntities = new AgencijaZaNekretnineEntities();
        public void AddZakazivanje(DateTime DatumVreme, int nekretninaID, int osobaID)
        {
            ZakazivanjeGledanjaNekretnineModel zakazivanjeGledanjaNekretnineModel = new ZakazivanjeGledanjaNekretnineModel()
            {
                DatumVreme = DatumVreme,
                KupacID = osobaID,
                NekretninaID = nekretninaID
            };
            agencijaZaNekretnineEntities.ZakazivanjeGledanjaNekretnineModels.Add(zakazivanjeGledanjaNekretnineModel);
            agencijaZaNekretnineEntities.SaveChanges();
        }

        public IEnumerable<ZakazivanjeGledanjaNekretnineBO> GetAllZakazivanjaByNekretnina(int nekretninaID)
        {
            List<ZakazivanjeGledanjaNekretnineBO> zakazivanje = new List<ZakazivanjeGledanjaNekretnineBO>();
            /*Potreban slozeniji upit za LINQ-u koji ne znam da napisem */
            foreach (ZakazivanjeGledanjaNekretnineModel zakazivanjeModel in agencijaZaNekretnineEntities.ZakazivanjeGledanjaNekretnineModels.Where(n =>n.NekretninaID==nekretninaID  ))
            {
                ZakazivanjeGledanjaNekretnineBO zakazivanjeBO = new ZakazivanjeGledanjaNekretnineBO()
                {
                    ZakazivanjeNekretnineID = zakazivanjeModel.ZakazivanjeID,
                    DatumVreme = (DateTime)zakazivanjeModel.DatumVreme,
                    Kupac = new OsobaBO()
                    {
                        OsobaId = zakazivanjeModel.Osoba.OsobaID
                    },
                    Nekretnina = new NekretninaBO()
                    {
                        NekretninaID = zakazivanjeModel.Nekretnina.NekretninaID
                    }

                };
                zakazivanje.Add(zakazivanjeBO);
            }
            return zakazivanje;
        }

        public IEnumerable<ZakazivanjeGledanjaNekretnineBO> GetAllZakazivanjaByOsoba(int osobaID)
        {
            List<ZakazivanjeGledanjaNekretnineBO> zakazivanje = new List<ZakazivanjeGledanjaNekretnineBO>();

            foreach (ZakazivanjeGledanjaNekretnineModel zakazivanjeModel in agencijaZaNekretnineEntities.ZakazivanjeGledanjaNekretnineModels.Include(n => n.Osoba).Include(i=>i.Nekretnina).Where(o => o.KupacID == osobaID))
            {
                ZakazivanjeGledanjaNekretnineBO zakazivanjeBO = new ZakazivanjeGledanjaNekretnineBO()
                {
                    ZakazivanjeNekretnineID = zakazivanjeModel.ZakazivanjeID,
                    DatumVreme = (DateTime)zakazivanjeModel.DatumVreme,
                    Kupac = new OsobaBO()
                    {
                        OsobaId = zakazivanjeModel.Osoba.OsobaID,
                        
                    },
                    Nekretnina = new NekretninaBO()
                    {
                        NekretninaID = zakazivanjeModel.Nekretnina.NekretninaID,
                        Adresa = zakazivanjeModel.Nekretnina.Adresa,
                        Opstina = zakazivanjeModel.Nekretnina.Opstina,
                        Vlasnik = new OsobaBO()
                        {
                            Ime = zakazivanjeModel.Nekretnina.Osoba.Ime,
                            Prezime = zakazivanjeModel.Nekretnina.Osoba.Prezime,
                            BrojMobilnog = zakazivanjeModel.Nekretnina.Osoba.BrojMobilnog,
                            Email = zakazivanjeModel.Nekretnina.Osoba.Email
                        }
                    }

                };
                zakazivanje.Add(zakazivanjeBO);
            }
            return zakazivanje;
        }
    }
}