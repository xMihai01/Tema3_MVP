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
    public class AbsentaDA
    {
        public void AddAbsenta(int? ElevID, int? MaterieID, int? SemestruID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddAbsenta", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTip = new SqlParameter("@Tip", "Nemotivata");
                SqlParameter paramData = new SqlParameter("@Date", DateTime.Now);
                SqlParameter paramElevID = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterieID = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestruID = new SqlParameter("@SemestruID", SemestruID);

                cmd.Parameters.Add(paramTip);
                cmd.Parameters.Add(paramData);
                cmd.Parameters.Add(paramElevID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramSemestruID);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteAbsenta(int? idAbsenta)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("MotiveazaAbsenta", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsenta = new SqlParameter("@AbsentaID", idAbsenta);
                cmd.Parameters.Add(paramIdAbsenta);
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
        public ObservableCollection<Absenta> GetAbsente(int? ElevID, int? MaterieID, int? SemestruID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetAbsentaForMaterie", connection);
                SqlParameter paramElev = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterie = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestru = new SqlParameter("SemestruID", SemestruID);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramMaterie);
                ObservableCollection<Absenta> Absente = new ObservableCollection<Absenta>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absenta abs = new Absenta();
                    abs.AbsentaID = reader.GetInt32(0);
                    abs.Tip = reader.GetString(1);
                    abs.Date= reader.GetDateTime(2);
                    abs.ElevMaterieID = reader.GetInt32(3);
                    Absente.Add(abs);
                }
                reader.Close();
                return Absente;
            }

        }
        public ObservableCollection<Absenta> GetAbsenteForElev(int? ElevID, int? SemestruID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetAbsenteForElev", connection);
                SqlParameter paramElev = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramSemestru = new SqlParameter("@SemestruID", SemestruID);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramElev);
                ObservableCollection<Absenta> Absente = new ObservableCollection<Absenta>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absenta abs = new Absenta();
                    abs.AbsentaID = reader.GetInt32(0);
                    abs.Tip = reader.GetString(1);
                    abs.Date = reader.GetDateTime(2);
                    abs.ElevMaterieID = reader.GetInt32(3);
                    Absente.Add(abs);
                }
                reader.Close();
                return Absente;
            }

        }

    }
}
