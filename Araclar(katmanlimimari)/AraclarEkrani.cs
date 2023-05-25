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
    public partial class AraclarEkrani : Form
    {
        public AraclarEkrani()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //listele butonu
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AracProsedürler.Listele();
        }
        //kaydet butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Araclar ekleme = new Araclar();
            ekleme.Aracadi = textBox1.Text;
            ekleme.AracOzellik = textBox2.Text;
            ekleme.Fiyat = Convert.ToInt32(textBox3.Text);
            ekleme.UretimYeri = textBox4.Text;

            if (BLEArac.Ekleme(ekleme)>0)
            {
                MessageBox.Show("Başarılı");
                dataGridView1.DataSource = AracProsedürler.Listele();

            }
            else
            {
                MessageBox.Show("Başarısız");
            }
        }
        //yenile
        private void button3_Click(object sender, EventArgs e)
        {
            Araclar veri = new Araclar();
            veri.aracno = Convert.ToInt32(textBox1.Tag);
            veri.Aracadi = textBox1.Text;
            veri.AracOzellik=textBox2.Text;
            veri.Fiyat=Convert.ToInt32(textBox3.Text);
            veri.UretimYeri=textBox4.Text;
            if(!AracProsedürler.Guncelle(veri))
            {
                MessageBox.Show("Güncellenemedi");
            }
            dataGridView1.DataSource = AracProsedürler.Listele();
        }
        //sil butonu
        private void button4_Click(object sender, EventArgs e)
        {
            Araclar veri=new Araclar();
            veri.aracno=Convert.ToInt32(textBox1.Tag);
            dataGridView1.DataSource = AracProsedürler.Listele();
            if(!AracProsedürler.Sil(veri))
            {
                MessageBox.Show("silinemedi");
            }
            dataGridView1.DataSource = AracProsedürler.Listele();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["AracNo"].Value.ToString();
            textBox1.Text = row.Cells["aracAdi"].Value.ToString();
            textBox2.Text = row.Cells["aracozellik"].Value.ToString();
            textBox3.Text = row.Cells["Fiyat"].Value.ToString();
            textBox4.Text = row.Cells["UretimYeri"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kategoriler k1=new Kategoriler();
            this.Hide();
            k1.Show();
        }
    }
}
