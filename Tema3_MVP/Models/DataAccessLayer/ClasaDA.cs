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
    public class ClasaDA
    {
        public void AddClasa(Clasa Clasa)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddClasa", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume_Clasa", Clasa.Nume);

                cmd.Parameters.Add(paramNume);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteClasa(int? idClasa)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteClasa", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdClasa = new SqlParameter("@id", idClasa);
                cmd.Parameters.Add(paramIdClasa);
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Clasa> GetClase()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetClase", connection);
                ObservableCollection<Clasa> Clase = new ObservableCollection<Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa c = new Clasa();
                    c.ClasaID = reader.GetInt32(0);
                    if (reader.IsDBNull(1)) c.DiriginteID = null; else c.DiriginteID = reader.GetInt32(1);
                    c.Nume = reader.GetString(2);
                    if (reader.IsDBNull(3)) c.SpecializareID = null; else c.SpecializareID = reader.GetInt32(3);
                    Clase.Add(c);
                }
                reader.Close();
                return Clase;
            }

        }
        public void UpdateClasa(Clasa Clasa)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateClasa", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@ClasaID", Clasa.ClasaID);
                SqlParameter paramNume = new SqlParameter("@Nume_Clasa", Clasa.Nume);
                SqlParameter paramDiriginteID;
                if (Clasa.DiriginteID == null)
                {
                    paramDiriginteID = new SqlParameter("@DiriginteID", DBNull.Value);
                }
                else
                {
                    paramDiriginteID = new SqlParameter("@DiriginteID", Clasa.DiriginteID);
                }
                SqlParameter paramSpecializareID;
                if (Clasa.SpecializareID == null)
                {
                    paramSpecializareID = new SqlParameter("@SpecializareID", DBNull.Value);
                }
                else
                {
                    paramSpecializareID = new SqlParameter("@SpecializareID", Clasa.SpecializareID);
                }
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramDiriginteID);
                cmd.Parameters.Add(paramSpecializareID);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Couldn't update entry. One of the given ids couldn't be found or an unknown error occurred");
                }
            }
        }
    }
}
