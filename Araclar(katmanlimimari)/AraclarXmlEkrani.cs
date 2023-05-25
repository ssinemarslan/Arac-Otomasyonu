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
    public partial class AraclarXmlEkrani : Form
    {
        public AraclarXmlEkrani()
        {
            InitializeComponent();
        }

        private void AraclarXmlEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument= new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Araclar");
            SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog = Araclar;Integrated security=true;");
            SqlCommand cmd = new SqlCommand("select*from AraclarBilgi", baglanti);
            baglanti.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                XmlElement arac = xmlDocument.CreateElement("Arac");
                XmlAttribute aracno = xmlDocument.CreateAttribute("AracNo");
                XmlAttribute aracadi = xmlDocument.CreateAttribute("AracAdi");
                XmlAttribute aracozellik = xmlDocument.CreateAttribute("AracOzellik");
                XmlAttribute fiyat = xmlDocument.CreateAttribute("Fiyat");
                XmlAttribute uretimyeri = xmlDocument.CreateAttribute("UretimYeri");

                aracno.Value = reader["AracNo"].ToString();
                aracadi.Value = reader["AracAdi"].ToString();
                aracozellik.Value = reader["AracOzellik"].ToString();
                fiyat.Value = reader["Fiyat"].ToString();
                uretimyeri.Value = reader["UretimYeri"].ToString();

                arac.Attributes.Append(aracno);
                arac.Attributes.Append(aracadi);
                arac.Attributes.Append(aracozellik);
                arac.Attributes.Append(fiyat);
                arac.Attributes.Append(uretimyeri);
            }
            baglanti.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("averi.xml");
        }
        public void Listele()
        {
            XmlDocument i = new XmlDocument();
            DataSet ds= new DataSet();
            XmlReader Xmlfile = XmlReader.Create(@"averi.xml", new XmlReaderSettings());
            ds.ReadXml(Xmlfile);
            dataGridView1.DataSource = ds.Tables[0];
            Xmlfile.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"averi.xml");
            x.Element("Araclar").Add(new XElement("AraclarBilgi",new XElement("AracNo",textBox1.Text),
                new XElement("AracAdi",textBox2.Text),
                new XElement("AracOzellik",textBox3.Text),
                new XElement("Fiyat",textBox4.Text),
                new XElement("UretimYeri",textBox5.Text)));
            x.Save(@"averi.xml");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"averi.xml");
            x.Root.Elements().Where(a => a.Element("AracNo").Value == textBox1.Text).Remove();
            x.Save(@"averi.xml");
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"averi.xml");
            XElement node=x.Elements("Araclar").Elements
                ("AraclarBilgi").FirstOrDefault(a=>a.Element("AracNo").Value==textBox1.Text);
            node.SetElementValue("AracAdi", textBox2.Text);
            node.SetElementValue("AracOzellik", textBox3.Text);
            node.SetElementValue("Fiyat", textBox4.Text);
            node.SetElementValue("UretimYeri",textBox5.Text);
            x.Save(@"averi.xml");
            Listele();
        }
    }
}
