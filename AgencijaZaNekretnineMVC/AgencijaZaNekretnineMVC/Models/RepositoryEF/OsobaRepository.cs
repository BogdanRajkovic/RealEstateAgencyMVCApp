using AgencijaZaNekretnineMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models.RepositoryEF
{
    public class OsobaRepository : IOsobaRepository
    {
        private AgencijaZaNekretnineEntities agencijaZaNekretnineEntities = new AgencijaZaNekretnineEntities();
        public void AddOsoba(OsobaBO osoba)
        {
            OsobaModel osobaModel = new OsobaModel()
            {
                Ime = osoba.Ime,
                Prezime = osoba.Prezime,
                KorisnickoIme = osoba.KorisnickoIme,
                Sifra = osoba.Sifra,
                Pol = osoba.Pol,
                JMBG = osoba.JMBG,
                BrojLicneKarte = osoba.BrojLicneKarte,
                Adresa = osoba.Adresa,
                BrojMobilnog = osoba.BrojMobilnog,
                Email = osoba.Email,
                IsAdmin = false
            };
            agencijaZaNekretnineEntities.OsobaModels.Add(osobaModel);
            agencijaZaNekretnineEntities.SaveChanges();
        }

        public void LoginOsoba(OsobaBO osoba)
        {
            throw new NotImplementedException();
        }

        public void LogOutOsoba(OsobaBO osoba)
        {
            throw new NotImplementedException();
        }
    }
}