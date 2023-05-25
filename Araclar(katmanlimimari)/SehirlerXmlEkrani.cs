using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Araclar_katmanlimimari_
{
    public partial class SehirlerXmlEkrani : Form
    {
        public SehirlerXmlEkrani()
        {
            InitializeComponent();
        }

        private void SehirlerXmlEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root=xmlDocument.CreateElement("Sehirler");
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog = Araclar;Integrated security=true;");
            SqlCommand cmd = new SqlCommand("select*from SehirlerBilgi", baglanti);
            baglanti.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                XmlElement sehir = xmlDocument.CreateElement("Sehir");
                XmlAttribute sehirno=xmlDocument.CreateAttribute("SehirNo");
                XmlAttribute sehiradi = xmlDocument.CreateAttribute("SehirAdi");
                XmlAttribute sehirbolge = xmlDocument.CreateAttribute("SehirBolge");
                XmlAttribute sehirnufus = xmlDocument.CreateAttribute("SehirNufus");
                XmlAttribute aracno = xmlDocument.CreateAttribute("AracNo");

                sehirno.Value = reader["SehirNo"].ToString();
                sehiradi.Value = reader["SehirAdi"].ToString();
                sehirbolge.Value = reader["SehirBolge"].ToString();
                sehirnufus.Value = reader["SehirNufus"].ToString();
                aracno.Value = reader["AracNo"].ToString();

                sehir.Attributes.Append(sehirno);
                sehir.Attributes.Append(sehiradi);
                sehir.Attributes.Append(sehirbolge);
                sehir.Attributes.Append(sehirnufus);
                sehir.Attributes.Append(aracno);
                root.AppendChild(sehir);
            }
            baglanti.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("sveri.xml");
        }
        public void Listele()
        {
            XmlDocument i = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader Xmlfile = XmlReader.Create(@"sveri.xml", new XmlReaderSettings());
            ds.ReadXml(Xmlfile);
            dataGridView1.DataSource = ds.Tables[0];
            Xmlfile.Close();
        }
        //ekle kaydet butonu
        private void button2_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"sveri.xml");
            x.Element("Araclar").Add(new XElement("SehirlerBilgi", new XElement("SehirNo", textBox1.Text),
                new XElement("SehirAdi", textBox2.Text),
                new XElement("SehirBolge", textBox3.Text),
                new XElement("SehirNufus", textBox4.Text),
                new XElement("AracNo", textBox5.Text)));
            x.Save(@"sveri.xml");
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        //sil butonu
        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"sveri.xml");
            x.Root.Elements().Where(a => a.Element("SehirNo").Value == textBox1.Text).Remove();
            x.Save(@"sveri.xml");
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //XDocument x = XDocument.Load(@"averi.xml");
            //XElement node = x.Elements("Araclar").Elements
            //    ("AraclarBilgi").FirstOrDefault(a => a.Element("AracNo").Value
            //    == textBox5.Text);
            //node.SetElementValue("AracAdi", textBox1.Text);
            //node.SetElementValue("AracOzellik", textBox2.Text);
            //node.SetElementValue("Fiyat", textBox3.Text);
            //node.SetElementValue("UretimYeri", textBox4.Text);
            //x.Save(@"averi.xml");
            //Listele();
            XDocument x = XDocument.Load(@"sveri.xml");
            XElement node=x.Elements("Araclar").Elements
                ("SehirlerBilgi").FirstOrDefault(a=>a.Element("SehirNo").Value==textBox1.Text);
            node.SetElementValue("SehirAdi",textBox2.Text);
            node.SetElementValue("SehirBolge",textBox3.Text);
            node.SetElementValue("SehirNufus",textBox4.Text);
            node.SetElementValue("AracNo",textBox5.Text);
            x.Save(@"sveri.xml");
            Listele();
        }
    }
}
