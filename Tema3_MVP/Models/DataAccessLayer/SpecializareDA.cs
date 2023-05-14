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
    public class SpecializareDA
    {
        public void AddSpecializare(Specializare Specializare)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddSpecializare", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", Specializare.Nume);

                cmd.Parameters.Add(paramNume);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteSpecializare(int? idSpecializare)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteSpecializare", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSpecializare = new SqlParameter("@id", idSpecializare);
                cmd.Parameters.Add(paramIdSpecializare);
                cmd.ExecuteNonQuery();
            }
        }
        public ObservableCollection<Specializare> GetSpecializari()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetSpecializari", connection);
                ObservableCollection<Specializare> Specializarei = new ObservableCollection<Specializare>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Specializare p = new Specializare();
                    p.SpecializareID = reader.GetInt32(0);
                    p.Nume = reader.GetString(1);
                    Specializarei.Add(p);
                }
                reader.Close();
                return Specializarei;
            }

        }
        public void UpdateSpecializare(Specializare Specializare)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateSpecializare", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@SpecializareID", Specializare.SpecializareID);
                SqlParameter paramNume = new SqlParameter("@Nume", Specializare.Nume);
          
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Couldn't update entry. unknown error occurred");
                }
            }
        }
    }
}
