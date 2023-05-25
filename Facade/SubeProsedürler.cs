using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;


namespace Facade
{
    public class SubeProsedürler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp=new SqlDataAdapter("SubelerListele",Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        public static int Ekleme(Subeler veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("SubeEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("Subeadi", veri.SubeAdi);
                komut.Parameters.AddWithValue("SubeAdres", veri.SubeAdres);
                komut.Parameters.AddWithValue("SubeTelefon", veri.SubeTelefon);
                komut.Parameters.AddWithValue("SehirNo", veri.SehirNo);
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
            
        }
        public static bool Guncelle(Subeler veri)
        {
            SqlCommand komut = new SqlCommand("SubeYenile", SBaglanti.con);
            komut.CommandType= CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("subeNo", veri.SubeNo);
            komut.Parameters.AddWithValue("SubeAdi", veri.SubeAdi);
            komut.Parameters.AddWithValue("SubeAdres", veri.SubeAdres);
            komut.Parameters.AddWithValue("SubeTelefon", veri.SubeTelefon);
            komut.Parameters.AddWithValue("SehirNo", veri.SehirNo);
            return SBaglanti.ExecuteNonQuery(komut);

        }
        public static bool Sil(Subeler veri)
        {
            SqlCommand komut = new SqlCommand("SubeSil", SBaglanti.con);
            komut.CommandType=CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SubeNo",veri.SubeNo);
            return SBaglanti.ExecuteNonQuery(komut);
        }
    }
}
