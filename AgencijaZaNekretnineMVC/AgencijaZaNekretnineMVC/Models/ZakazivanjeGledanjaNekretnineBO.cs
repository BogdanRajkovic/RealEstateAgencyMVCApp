using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models
{
    [Table("tblZakazivanjeGledanjaNekretnine")]
    public class ZakazivanjeGledanjaNekretnineBO
    {
        #region Properties 
        public int ZakazivanjeNekretnineID { get; set; }
        [DisplayName("Datum")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required]
        public DateTime DatumVreme { get; set; }

        public OsobaBO Kupac { get; set; }
        
        public NekretninaBO Nekretnina { get; set; }
        #endregion
    }
}