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
    public partial class SubelerXmlEkrani : Form
    {
        public SubelerXmlEkrani()
        {
            InitializeComponent();
        }

        private void SubelerXmlEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Subeler");
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog = Araclar;Integrated security=true;");
            SqlCommand cmd = new SqlCommand("select*from SubelerBilgi", baglanti);
            baglanti.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                XmlElement sube = xmlDocument.CreateElement("Sube");
                XmlAttribute subeno = xmlDocument.CreateAttribute("SubeNo");
                XmlAttribute subeadi = xmlDocument.CreateAttribute("SubeAdi");
                XmlAttribute subeadres = xmlDocument.CreateAttribute("SubeAdres");
                XmlAttribute subetelefon = xmlDocument.CreateAttribute("SubeTelefon");
                XmlAttribute sehirno = xmlDocument.CreateAttribute("SehirNo");

                subeno.Value = reader["SubeNo"].ToString();
                subeadi.Value = reader["SubeAdi"].ToString();
                subeadres.Value = reader["SubeAdres"].ToString();
                subetelefon.Value = reader["SubeTelefon"].ToString();
                sehirno.Value = reader["SehirNo"].ToString();

                sube.Attributes.Append(subeno);
                sube.Attributes.Append(subeadi);
                sube.Attributes.Append(subeadres);
                sube.Attributes.Append(subetelefon);
                sube.Attributes.Append(sehirno);

            }
            baglanti.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("subelerveri.xml");
        }
        public void Listele()
        {
            XmlDocument i = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader Xmlfile = XmlReader.Create(@"subelerveri.xml", new XmlReaderSettings());
            ds.ReadXml(Xmlfile);
            dataGridView1.DataSource = ds.Tables[0];
            Xmlfile.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"subelerveri.xml");
            x.Element("Araclar").Add(new XElement("SubelerBilgi", new XElement("SubeNo", textBox1.Text),
            new XElement("SubeAdi", textBox2.Text),
            new XElement("SubeAdres", textBox3.Text),
            new XElement("SubeTelefon", textBox4.Text),
            new XElement("SehirNo", textBox5.Text)));
            x.Save(@"subelerveri.xml");
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"subelerveri.xml");
            x.Root.Elements().Where(a => a.Element("SubeNo").Value == textBox1.Text).Remove();
            x.Save(@"subelerveri.xml");
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"subelerveri.xml");
            XElement node=x.Elements("Araclar").Elements
                ("SubelerBilgi").FirstOrDefault(a=>a.Element("SubeNo").Value==textBox1.Text);
            node.SetElementValue("SubeAdi",textBox2.Text);
            node.SetElementValue("SubeAdres", textBox3.Text);
            node.SetElementValue("SubeTelefon", textBox4.Text);
            node.SetElementValue("SehirNo", textBox5);
            x.Save(@"subelerveri.xml");
            Listele();
        }
    }
    


}
