using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    internal class SBaglanti
    {
        public static readonly SqlConnection con = new SqlConnection("Server=DESKTOP-9KURH7U\\SQLEXPRESS;Database=Araclar;Integrated Security=true;");

        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if(komut.Connection.State !=ConnectionState.Open)
                {
                    komut.Connection.Open();
                    return komut.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if(komut.Connection.State !=ConnectionState.Closed)
                {
                    komut.Connection.Close();
                }
            }
            return true;
        }    

    }
}
