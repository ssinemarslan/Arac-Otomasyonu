using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Araclar
    {
        private int _Aracno;
        private string _AracAdi;
        private string _AracOzellik;
        private int _Fiyat;
        private string _UretimYeri;

        public int aracno
        {
            get { return _Aracno; }
            set { _Aracno = value; }
        }
        public string Aracadi
        {
            get { return _AracAdi; }
            set { _AracAdi = value; }
        }
        public string AracOzellik
        {
            get { return _AracOzellik; }
            set { _AracOzellik = value;}
        }
        public int Fiyat
        {
            get { return _Fiyat;}
            set { _Fiyat = value;}
        }
        public string UretimYeri
        {
            get { return _UretimYeri;}
            set { _UretimYeri = value;}
        }
    }
}
