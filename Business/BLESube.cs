using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facade;


namespace Business
{
    public class BLESube
    {
        public static int Ekleme(Subeler veri)
        {
            if(veri.SubeAdi !=null && veri.SubeAdi.Trim().Length > 0)
            {
                return SubeProsedürler.Ekleme(veri);
            }
            return -1;
        }
    }
}
