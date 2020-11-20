using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencijaZaNekretnineMVC.Models.Interfaces
{
    interface IOsobaRepository
    {
        void AddOsoba(OsobaBO osoba);

        void LoginOsoba(OsobaBO osoba);

        void LogOutOsoba(OsobaBO osoba);
    }//interface
}//namespace
