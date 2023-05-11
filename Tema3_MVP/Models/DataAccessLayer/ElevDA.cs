using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Utils;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class ElevDA
    {
        public static void AddElev(Elev elev)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddElev", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", elev.Nume);
                SqlParameter paramPrenume = paramPrenume = new SqlParameter("@Prenume", elev.Prenume);
                
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteElev(int idElev)
        {
            using (SqlConnection connection = DataAccessUtil.connection)
            {
                SqlCommand cmd = new SqlCommand("DellElev", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id", idElev);
                cmd.Parameters.Add(paramIdElev);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
