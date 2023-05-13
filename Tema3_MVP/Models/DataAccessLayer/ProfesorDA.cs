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
    public class ProfesorDA
    {
        public void AddProfesor(Profesor Profesor)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddProfesor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", Profesor.Nume);
                SqlParameter paramPrenume = new SqlParameter("@Prenume", Profesor.Prenume);

                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProfesor(int? idProfesor)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteProfesor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProfesor = new SqlParameter("@id", idProfesor);
                cmd.Parameters.Add(paramIdProfesor);
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Profesor> GetProfesori()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetProfesori", connection);
                ObservableCollection<Profesor> Profesori = new ObservableCollection<Profesor>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Profesor p = new Profesor();
                    p.ProfesorID = reader.GetInt32(0);
                    p.Nume = reader.GetString(1);//reader[1].ToString();
                    p.Prenume = reader.GetString(2);
                    if (reader.IsDBNull(3)) p.ClasaID = null; else p.ClasaID = reader.GetInt32(3);
                    Profesori.Add(p);
                }
                reader.Close();
                return Profesori;
            }

        }
        public void UpdateProfesor(Profesor Profesor)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateProfesor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@ProfesorID", Profesor.ProfesorID);
                SqlParameter paramNume = new SqlParameter("@Nume", Profesor.Nume);
                SqlParameter paramPrenume = new SqlParameter("@Prenume", Profesor.Prenume);
                SqlParameter paramClasaID;
                if (Profesor.ClasaID == null)
                {
                    paramClasaID = new SqlParameter("@ClasaID", DBNull.Value);
                }
                else
                {
                    paramClasaID = new SqlParameter("@ClasaID", Profesor.ClasaID);
                }
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                cmd.Parameters.Add(paramClasaID);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Couldn't update entry. Given id_clasa couldn't be found or an unknown error occurred");
                }
            }
        }
    }
}
