using AgencijaZaNekretnineMVC.Models.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models
{
    public class NekretninaBO
    {
        #region Properties
        public int NekretninaID { get; set; }
        [Required(ErrorMessage = "Unesite Adresu nekretnine")]

        public string Adresa { get; set; }
        [Required(ErrorMessage = "Unesite opstinu")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Opsina moze sadrzati samo slova")]
        public string Opstina { get; set; }
        [Required(ErrorMessage = "Unesite spratnost")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Moguce je uneti samo brojeve")]
        public int Spratnost { get; set; }
        [Required(ErrorMessage = "Unesite povrsinu")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Moguce je uneti samo brojeve")]
        public float Povrsina { get; set; }
        [Required(ErrorMessage = "Unesite cenu")]
        [RegularExpression("^([1-9][0-9]*)$", ErrorMessage = "Moguce je uneti samo brojeve")]
        public double Cena { get; set; }
        [Required(ErrorMessage = "Unesite namestenost")]
        public string Namestenost { get; set; }
        [Required(ErrorMessage = "Unesite vrstu nekretnine")]
        [DisplayName("Vrsta Nekretnine")]
        public string VrstaNekretnine { get; set; }
        [Required(ErrorMessage = "Unesite strukturu")]
        public string Struktura { get; set; }
        [Required(ErrorMessage = "Unesite stanje")]
        public string Stanje { get; set; }
        [Required(ErrorMessage = "Unesite sprat")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Sprat mora biti broj")]
        public int Sprat { get; set; }
        [DisplayName("Dodatne karakteristike")]
        public string DodatneKarakteristike { get; set; }
        public string Napomena { get; set; }
        [DisplayName("Slike Nekretnine")]
        public string NekretnineSlike
        {
            get => JsonConvert.SerializeObject(Slike);
            set => Slike = JsonConvert.DeserializeObject<List<Slika>>(value);
        }

        public OsobaBO Vlasnik = new OsobaBO();

        #endregion

        public List<Slika> Slike { get; set; }

        [NotMapped]
        public List<HttpPostedFileBase> Files { get; set; }
    }
}