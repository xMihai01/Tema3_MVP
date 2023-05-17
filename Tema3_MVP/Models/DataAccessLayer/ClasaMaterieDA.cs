using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Utils;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class ClasaMaterieDA
    {
        public void AddClasaMaterie(ClasaMaterie ClasaMaterie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddClasaMaterie", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramClasaID = new SqlParameter("@ClasaID", ClasaMaterie.ClasaID);
                    SqlParameter paramMaterieID = new SqlParameter("@MaterieID", ClasaMaterie.MaterieID);
                    SqlParameter paramTeza = new SqlParameter("@Teza", ClasaMaterie.Teza);

                    cmd.Parameters.Add(paramClasaID);
                    cmd.Parameters.Add(paramMaterieID);
                    cmd.Parameters.Add(paramTeza);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void DeleteClasaMaterie(int? idClasaMaterie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteClasaMaterie", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdClasaMaterie = new SqlParameter("@id", idClasaMaterie);
                cmd.Parameters.Add(paramIdClasaMaterie);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public ObservableCollection<ClasaMaterie> GetClaseMaterii()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetClaseMaterii", connection);
                ObservableCollection<ClasaMaterie> Clase = new ObservableCollection<ClasaMaterie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClasaMaterie c = new ClasaMaterie();
                    c.ClasaID = reader.GetInt32(0);
                    c.MaterieID = reader.GetInt32(1);
                    c.Teza = reader.GetBoolean(2);
                    c.ClasaMaterieID = reader.GetInt32(3);
                    Clase.Add(c);
                }
                reader.Close();
                return Clase;
            }

        }
        public ClasaMaterie GetClasaMaterie(int? ClasaID, int? MaterieID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetClasaMaterie", connection);
                SqlParameter paramClasaID = new SqlParameter("@ClasaID", ClasaID);
                SqlParameter paramMaterieID = new SqlParameter("@MaterieID", MaterieID);
                cmd.Parameters.Add(paramClasaID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                ClasaMaterie c = null;
                if (reader.Read())
                {
                    c = new ClasaMaterie();
                    c.ClasaID = reader.GetInt32(0);
                    c.MaterieID = reader.GetInt32(1);
                    c.Teza = reader.GetBoolean(2);
                    c.ClasaMaterieID = reader.GetInt32(3);
            
                }
                reader.Close();
                return c;
            }

        }
    }
}
