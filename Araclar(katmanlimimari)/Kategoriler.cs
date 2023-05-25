using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araclar_katmanlimimari_
{
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AraclarEkrani a1= new AraclarEkrani();
            this.Hide();
            a1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SehirlerEkrani s1=new SehirlerEkrani();
            this.Hide();
            s1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubelerEkrani s2=new SubelerEkrani();
            this.Hide();
            s2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AraclarXmlEkrani a2 = new AraclarXmlEkrani();
            this.Hide();
            a2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SehirlerXmlEkrani s3 = new SehirlerXmlEkrani();
            this.Hide();
            s3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SubelerXmlEkrani s4= new SubelerXmlEkrani();
            this.Hide();
            s4.Show();
        }
    }
}
