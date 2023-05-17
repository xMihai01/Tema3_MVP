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

        /*public ObservableCollection<Absenta> GetClaseForProfesor(int? ProfesorID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetClaseForProfesor", connection);
                SqlParameter paramID = new SqlParameter("@ProfesorID", ProfesorID);
                cmd.Parameters.Add(paramID);
                ObservableCollection<Absenta> Clase = new ObservableCollection<Absenta>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absenta c = new Absenta();
                    c.AbsentaID = reader.GetInt32(0);
                    if (reader.IsDBNull(1)) c.DiriginteID = null; else c.DiriginteID = reader.GetInt32(1);
                    c.Nume = reader.GetString(2);
                    if (reader.IsDBNull(3)) c.SpecializareID = null; else c.SpecializareID = reader.GetInt32(3);
                    Clase.Add(c);
                }
                reader.Close();
                return Clase;
            }

        }
        public void UpdateAbsenta(Absenta Absenta)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateAbsenta", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@AbsentaID", Absenta.AbsentaID);
                SqlParameter paramNume = new SqlParameter("@Nume_Absenta", Absenta.Nume);
                SqlParameter paramDiriginteID;
                if (Absenta.DiriginteID == null)
                {
                    paramDiriginteID = new SqlParameter("@DiriginteID", DBNull.Value);
                }
                else
                {
                    paramDiriginteID = new SqlParameter("@DiriginteID", Absenta.DiriginteID);
                }
                SqlParameter paramSpecializareID;
                if (Absenta.SpecializareID == null)
                {
                    paramSpecializareID = new SqlParameter("@SpecializareID", DBNull.Value);
                }
                else
                {
                    paramSpecializareID = new SqlParameter("@SpecializareID", Absenta.SpecializareID);
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
        }*/
    }
}
