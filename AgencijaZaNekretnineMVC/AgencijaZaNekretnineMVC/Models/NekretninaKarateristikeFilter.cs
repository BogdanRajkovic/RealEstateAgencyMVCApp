using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models
{
    public class NekretninaKarateristikeFilter
    {
        public string Opstina { get; set; }
        public float? Povrsina { get; set; }
        public decimal? CenaNajniza { get; set; }
        public decimal? CenaNajvisa { get; set; }
        public string VrstaNekretnine { get; set; }

    }
}