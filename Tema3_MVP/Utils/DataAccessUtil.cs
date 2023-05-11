using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Utils
{
    public class DataAccessUtil
    {
        private static string connectionString = @"Data Source=DESKTOP-P7V6FRH\SQLEXPRESS01;Initial Catalog=Tema3;Integrated Security=True";
        public static SqlConnection connection;
        public static SqlConnection Connect()
        {
            connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
