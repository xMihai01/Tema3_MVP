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
    public class SemestruDA
    {
        public void AddSemestru(Semestru Semestru)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddSemestru", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", Semestru.Nume);

                cmd.Parameters.Add(paramNume);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteSemestru(int? idSemestru)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteSemestru", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSemestru = new SqlParameter("@id", idSemestru);
                cmd.Parameters.Add(paramIdSemestru);
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
        public ObservableCollection<Semestru> GetSemestre()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetSemestre", connection);
                ObservableCollection<Semestru> Semestrui = new ObservableCollection<Semestru>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Semestru p = new Semestru();
                    p.SemestruID = reader.GetInt32(0);
                    p.Nume = reader.GetString(1);
                    Semestrui.Add(p);
                }
                reader.Close();
                return Semestrui;
            }

        }
    }
}
