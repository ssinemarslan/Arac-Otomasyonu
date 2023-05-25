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
    public class AracProsedürler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("AraclarListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static int Ekleme(Araclar veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("AracEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if(komut.Connection.State !=ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("AracAdi", veri.Aracadi);
                komut.Parameters.AddWithValue("AracOzellik", veri.AracOzellik);
                komut.Parameters.AddWithValue("Fiyat", veri.Fiyat);
                komut.Parameters.AddWithValue("UretimYeri", veri.UretimYeri);
                islem = komut.ExecuteNonQuery();
            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static bool Guncelle(Araclar veri)
        {
            SqlCommand komut = new SqlCommand("AracYenile", SBaglanti.con);
            komut.CommandType=CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("AracNo",veri.aracno);
            komut.Parameters.AddWithValue("AracAdi", veri.Aracadi);
            komut.Parameters.AddWithValue("AracOzellik", veri.AracOzellik);
            komut.Parameters.AddWithValue("Fiyat", veri.Fiyat);
            komut.Parameters.AddWithValue("UretimYeri", veri.UretimYeri);
            return SBaglanti.ExecuteNonQuery(komut);
        }
        public static bool Sil (Araclar veri)
        {
            SqlCommand komut = new SqlCommand("AracSil",SBaglanti.con);
            komut.CommandType= CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("AracNo",veri.aracno);
            return SBaglanti.ExecuteNonQuery(komut);
        }
    }
}
