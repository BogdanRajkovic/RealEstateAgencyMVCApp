using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models
{
    public class PrikazSvihNekretnina
    {
        public NekretninaKarateristikeFilter Filter { get; set; }
        public List<NekretninaBO> Nekretnine { get; set; }
    }
}