using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Entity
{
    public class Sehirler
    {
        private int _SehirNo;
        private string _SehirAdi;
        private string _SehirBolge;
        private int _SehirNufus;
        private int _AracNo;

        public int SehirNo
        {
            get { return _SehirNo; }
            set { _SehirNo = value; }
        }
        public string SehirAdi
        {
            get { return _SehirAdi; }
            set { _SehirAdi = value; }
        }
        public string SehirBolge
        {
            get { return _SehirBolge; }
            set { _SehirBolge = value; }
        }
        public int SehirNufus
        {
            get { return _SehirNufus; }
            set { _SehirNufus = value; }
        }
        public int AracNo
        {
            get { return _AracNo; }
            set { _AracNo = value; }
        }

    }
}
