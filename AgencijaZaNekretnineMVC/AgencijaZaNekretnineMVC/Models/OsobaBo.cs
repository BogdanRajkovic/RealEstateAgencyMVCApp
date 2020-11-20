using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models
{
    public class OsobaBO
    {
        #region Properties
        public int OsobaId { get; set; }

        [Required(ErrorMessage = "Unesite Vase Ime")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Ime moze sadrzati samo slova")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite Vase prezime")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Prezime moze sadrzati samo slova")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite Vase korisnicko ime")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Unesite Vasu sifru")]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
        [Required(ErrorMessage = "Unesite Vas pol")]
        public string Pol { get; set; }
       
        [Required(ErrorMessage = "Unesite Vas jedinstveni maticni broj gradjana")]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "JMBG nije u dobrom formatu")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Unesite Vas broj licne karte")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Broj licne karte nije u dobrom formatu")]
        public string BrojLicneKarte { get; set; }
        [Required(ErrorMessage = "Unesite Vasu adresu stanovanja")]

        public string Adresa { get; set; }
        [Required(ErrorMessage = "Unesite Vas broj mobilnog telefona")]
        [RegularExpression("^[0-9]{12,20}$",ErrorMessage ="Broj mobilnog nije u dobrom formatu")]
        [DisplayName("Broj mobilnog")]
        public string BrojMobilnog { get; set; }
        [Required(ErrorMessage = "Unesite Vas e-mail")]
        [EmailAddress(ErrorMessage = "Email nije u dobrom formatu")]
        public string Email { get; set; }
        public string IsAdmin { get; set; }
        [DisplayName("Ime i Prezime")]
        public string ImePrezime
        {
            get { return Ime + " " + Prezime; }
        }
       
    #endregion

}
}