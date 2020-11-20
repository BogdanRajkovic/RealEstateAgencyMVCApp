using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AgencijaZaNekretnineMVC.Models.Interfaces
{
    interface INekretninaRepository
    {
        void AddNekretnina(NekretninaBO nekretnina, List<HttpPostedFileBase> files);
        void UpdateNekretnina(NekretninaBO nekretnina, List<HttpPostedFileBase> files);
        IEnumerable<NekretninaBO> GetAllNekretnine();

        NekretninaBO GetSingle(int id);
        IEnumerable<NekretninaBO> GetNekretnineByKarakteristke(NekretninaKarateristikeFilter filter);
    }
}
