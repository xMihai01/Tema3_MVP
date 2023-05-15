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
    public class ProfesorMaterieDA
    {
        public void AddProfesorMaterie(ProfesorMaterie ProfesorMaterie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddProfesorMaterie", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramProfesorID = new SqlParameter("@ProfesorID", ProfesorMaterie.ProfesorID);
                    SqlParameter paramMaterieID = new SqlParameter("@MaterieID", ProfesorMaterie.MaterieID);

                    cmd.Parameters.Add(paramProfesorID);
                    cmd.Parameters.Add(paramMaterieID);
    
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void DeleteProfesorMaterie(int? idProfesorMaterie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteProfesorMaterie", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProfesorMaterie = new SqlParameter("@id", idProfesorMaterie);
                cmd.Parameters.Add(paramIdProfesorMaterie);
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
        public ObservableCollection<ProfesorMaterie> GetProfesorMaterii()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetProfesorMaterii", connection);
                ObservableCollection<ProfesorMaterie> Clase = new ObservableCollection<ProfesorMaterie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProfesorMaterie c = new ProfesorMaterie();
                    c.ProfesorID = reader.GetInt32(1);
                    c.MaterieID = reader.GetInt32(2);
                    c.ProfesorMaterieID = reader.GetInt32(0);
                    Clase.Add(c);
                }
                reader.Close();
                return Clase;
            }

        }
    }
}
