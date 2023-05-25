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
    public class BLEArac
    {
        public static int Ekleme(Araclar veri)
        {
            if (veri.Aracadi != null && veri.Aracadi.Trim().Length > 0)
            {
                return AracProsedürler.Ekleme(veri);
            }
            return -1;
        }
    }
}
