using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Subeler
    {
        private int _SubeNo;
        private string _SubeAdi;
        private string _SubeAdres;
        private string _SubeTelefon;
        private int _SehirNo;

        public int SubeNo
        {
            get { return _SubeNo; }
            set { _SubeNo = value; }
        }
        public string SubeAdi
        {
            get { return _SubeAdi; }
            set { _SubeAdi = value;}
        }
        public string SubeAdres
        {
            get { return _SubeAdres; }
            set { _SubeAdres = value; }
        }
        public string SubeTelefon
        {
            get { return _SubeTelefon;}
            set { _SubeTelefon = value;}
        }
        public int SehirNo
        {
            get { return _SehirNo; }
            set { _SehirNo = value;}
        }
    }
}
