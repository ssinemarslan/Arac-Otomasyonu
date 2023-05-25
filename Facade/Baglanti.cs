using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    internal class Baglanti
    {
        public static readonly SqlConnection con = new SqlConnection("Server=DESKTOP-9KURH7U\\SQLEXPRESS;Database=Araclar;Integrated Security=true;");
    }
}
