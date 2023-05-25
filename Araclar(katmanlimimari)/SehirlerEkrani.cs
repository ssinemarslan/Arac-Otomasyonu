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
    public partial class SehirlerEkrani : Form
    {
        public SehirlerEkrani()
        {
            InitializeComponent();
        }
        //listele butonu
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SehirProsedürler.Listele();
        }
        //kaydet-ekle butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Sehirler ekleme = new Sehirler();
            ekleme.SehirAdi = textBox1.Text;
            ekleme.SehirBolge = textBox2.Text;
            ekleme.SehirNufus = Convert.ToInt32(textBox3.Text);
            ekleme.AracNo = Convert.ToInt32(textBox4.Text);

            if (BLESehir.Ekleme(ekleme) > 0)
            {
                MessageBox.Show("Başarılı");
                dataGridView1.DataSource = SehirProsedürler.Listele();

            }
            else
            {
                MessageBox.Show("Başarısız");
            }
        }
        //yenile butonu
        private void button3_Click(object sender, EventArgs e)
        {
            Sehirler veri = new Sehirler();
            veri.SehirNo = Convert.ToInt32(textBox1.Tag);
            veri.SehirAdi = textBox1.Text;
            veri.SehirBolge = textBox2.Text;
            veri.SehirNufus = Convert.ToInt32(textBox3.Text);
            veri.AracNo = Convert.ToInt32(textBox4.Text);
            if (!SehirProsedürler.Guncelle(veri))
            {
                MessageBox.Show("Güncellenemedi");
            }
            dataGridView1.DataSource = SehirProsedürler.Listele();
        }
        //sil butonu
        private void button4_Click(object sender, EventArgs e)
        {
            Sehirler veri = new Sehirler();
            veri.SehirNo = Convert.ToInt32(textBox1.Tag);
            dataGridView1.DataSource = SehirProsedürler.Listele();
            if (!SehirProsedürler.Sil(veri))
            {
                MessageBox.Show("silinemedi");
            }
            dataGridView1.DataSource = SehirProsedürler.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["sehirNo"].Value.ToString();
            textBox1.Text = row.Cells["sehirAdi"].Value.ToString();
            textBox2.Text = row.Cells["sehirbolge"].Value.ToString();
            textBox3.Text = row.Cells["sehirnufus"].Value.ToString();
            textBox4.Text = row.Cells["AracNo"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kategoriler k1 = new Kategoriler();
            this.Hide();
            k1.Show();
        }
    }
}
