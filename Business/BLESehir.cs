using Entity;
using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facade;

namespace Business
{
    public class BLESehir
    {
        public static int Ekleme(Sehirler veri)
        {
            if (veri.SehirAdi != null && veri.SehirAdi.Trim().Length > 0)
            {
                return SehirProsedürler.Ekleme(veri);
            }
            return -1;
        }
    }
}
