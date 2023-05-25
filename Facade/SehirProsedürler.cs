using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Facade
{
    public class SehirProsedürler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("SehirlerListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static int Ekleme(Sehirler veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("SehirEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("Sehiradi", veri.SehirAdi);
                komut.Parameters.AddWithValue("SehirBolge", veri.SehirBolge);
                komut.Parameters.AddWithValue("SehirNufus", veri.SehirNufus);
                komut.Parameters.AddWithValue("AracNo", veri.AracNo);
                islem = komut.ExecuteNonQuery();
            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static bool Guncelle(Sehirler veri)
        {
            SqlCommand komut = new SqlCommand("SehirYenile", SBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SehirNo", veri.SehirNo);
            komut.Parameters.AddWithValue("SehirAdi", veri.SehirAdi);
            komut.Parameters.AddWithValue("SehirBolge", veri.SehirBolge);
            komut.Parameters.AddWithValue("SehirNufus", veri.SehirNufus);
            komut.Parameters.AddWithValue("AracNo", veri.AracNo);
            return SBaglanti.ExecuteNonQuery(komut);

        }
        public static bool Sil(Sehirler veri)
        {
            SqlCommand komut = new SqlCommand("SehirSil", SBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SehirNo", veri.SehirNo);
            return SBaglanti.ExecuteNonQuery(komut);
        }
    }
}
