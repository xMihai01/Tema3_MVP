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
    public class NotaDA
    {
        public void AddNota(int? ElevID, int? MaterieID, int? SemestruID, double Nota, bool isTeza)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddNota", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTip;
                if (isTeza) paramTip = new SqlParameter("@Tip", "TEZA"); else paramTip = new SqlParameter("@Tip", "NOTA");
                SqlParameter paramNota = new SqlParameter("@ValoareNota", Nota);
                SqlParameter paramData = new SqlParameter("@Date", DateTime.Now);
                SqlParameter paramElevID = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterieID = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestruID = new SqlParameter("@SemestruID", SemestruID);

                cmd.Parameters.Add(paramTip);
                cmd.Parameters.Add(paramNota);
                cmd.Parameters.Add(paramData);
                cmd.Parameters.Add(paramElevID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramSemestruID);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteNota(int? idNota)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("CancelNota", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdNota = new SqlParameter("@NotaID", idNota);
                cmd.Parameters.Add(paramIdNota);
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
        public ObservableCollection<Nota> GetNote(int? ElevID, int? MaterieID, int? SemestruID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetNoteForMaterieAndElev", connection);
                SqlParameter paramElev = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterie = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestru = new SqlParameter("SemestruID", SemestruID);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramMaterie);
                ObservableCollection<Nota> Note = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota n = new Nota();
                    n.NotaID = reader.GetInt32(0);
                    n.Tip = reader.GetString(1);
                    n.ValoareNota = reader.GetDouble(2);
                    n.Date = reader.GetDateTime(3);
                    n.ElevMaterieID = reader.GetInt32(4);
                    Note.Add(n);
                }
                reader.Close();
                return Note;
            }

        }
        public void SetMedie(int? ElevID, int? MaterieID, int? SemestruID, double? medie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SetMedie", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNota = new SqlParameter("@Medie", medie);
                SqlParameter paramElev = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterie = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestru = new SqlParameter("SemestruID", SemestruID);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramMaterie);
                cmd.Parameters.Add(paramNota);

                cmd.ExecuteNonQuery();
            }
        }
        public double? GetMedie(int? ElevID, int? MaterieID, int? SemestruID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetMedie", connection);
                SqlParameter paramElev = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterie = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestru = new SqlParameter("SemestruID", SemestruID);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramMaterie);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                double? value = null;
                if (reader.Read())
                {
                    if (reader.IsDBNull(0)) value = null; else value = reader.GetDouble(0);
                   
                }
                reader.Close();
                return value;
            }

        }

    }
}
