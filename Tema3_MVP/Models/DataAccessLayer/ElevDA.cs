using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Utils;
using System.Collections.ObjectModel;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class ElevDA
    {
        public void AddElev(Elev elev)
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
        public void DeleteElev(int? idElev)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteElev", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id", idElev);
                cmd.Parameters.Add(paramIdElev);
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Elev> GetElevi()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetElevi", connection);
                ObservableCollection<Elev> elevi = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev p = new Elev();
                    p.ElevID = reader.GetInt32(0);
                    p.Nume = reader.GetString(1);//reader[1].ToString();
                    p.Prenume = reader.GetString(2);
                    if (reader.IsDBNull(3)) p.ClasaID = null; else p.ClasaID = reader.GetInt32(3);
                    elevi.Add(p);
                }
                reader.Close();
                return elevi;
            }
            
        }
    }
}
