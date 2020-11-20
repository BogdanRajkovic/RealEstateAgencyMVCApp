using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencijaZaNekretnineMVC.Models.Interfaces
{
    interface IZakazivanjeGledanjaNekretnineRepository
    {
        void AddZakazivanje(DateTime DatumVreme, int nekretninaID, int osobaID);

        IEnumerable<ZakazivanjeGledanjaNekretnineBO> GetAllZakazivanjaByOsoba(int osobaID);
        //Nisam siguran da li treba da prosledim osobu kao parametar ove funkcije ili je bolje samo ID te osobe i onda dobijem izlistavana za sva zakazivanja
        IEnumerable<ZakazivanjeGledanjaNekretnineBO> GetAllZakazivanjaByNekretnina(int nekretninaID);
    }
}
