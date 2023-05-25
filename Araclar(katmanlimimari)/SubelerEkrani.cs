using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facade;
using Entity;
using Business;

namespace Araclar_katmanlimimari_
{
    public partial class SubelerEkrani : Form
    {
        public SubelerEkrani()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["subeno"].Value.ToString();
            textBox1.Text = row.Cells["subeadi"].Value.ToString();
            textBox2.Text = row.Cells["SubeAdres"].Value.ToString();
            textBox3.Text = row.Cells["SubeTelefon"].Value.ToString();
            textBox4.Text = row.Cells["SehirNo"].Value.ToString();
        }
        //listele butonu
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SubeProsedürler.Listele();
        }
        //ekleme kaydetme butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Subeler ekleme = new Subeler();
            ekleme.SubeAdi = textBox1.Text;
            ekleme.SubeAdres= textBox2.Text;
            ekleme.SubeTelefon=textBox3.Text;
            ekleme.SehirNo = Convert.ToInt32(textBox4.Text);
            if (BLESube.Ekleme(ekleme) > 0)
            {
                MessageBox.Show("Başarılı");
                dataGridView1.DataSource = SubeProsedürler.Listele();
            }
            else
            {
                MessageBox.Show("Başarısız");

            }
        }
        //yenile butonu
        private void button3_Click(object sender, EventArgs e)
        {
            Subeler veri = new Subeler();
            veri.SubeNo = Convert.ToInt32(textBox1.Tag);
            veri.SubeAdi = textBox1.Text;
            veri.SubeAdres= textBox2.Text;
            veri.SubeTelefon=textBox3.Text;
            veri.SehirNo= Convert.ToInt32(textBox4.Text);
            if(!SubeProsedürler.Guncelle(veri))
            {
                MessageBox.Show("Güncellenemedi");
            }
            dataGridView1.DataSource = SubeProsedürler.Listele();

        }
        //sil butonu
        private void button4_Click(object sender, EventArgs e)
        {
            Subeler veri = new Subeler();
            veri.SubeNo= Convert.ToInt32(textBox1.Tag);
            dataGridView1.DataSource = SubeProsedürler.Listele();
            if(!SubeProsedürler.Sil(veri))
            {
                MessageBox.Show("Silinemedi");
            }
            dataGridView1.DataSource = SubeProsedürler.Listele();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kategoriler k1 = new Kategoriler();
            this.Hide();
            k1.Show();
        }
    }
}
