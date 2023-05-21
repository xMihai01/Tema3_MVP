using System;
using System.Collections.Generic;
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
    public class ElevMaterieDA
    {
        public void AddElevMaterie(ElevMaterie ElevMaterie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddStudentMaterie", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramElevID = new SqlParameter("@ElevID", ElevMaterie.ElevID);
                    SqlParameter paramMaterieID = new SqlParameter("@MaterieID", ElevMaterie.MaterieID);
                    SqlParameter paramTeza = new SqlParameter("@SemestruID", ElevMaterie.SemestruID);

                    cmd.Parameters.Add(paramElevID);
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
        public ElevMaterie GetElevMaterie(int? ElevID, int? MaterieID, int? SemestruID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetElevMaterie", connection);
                SqlParameter paramElevID = new SqlParameter("@ElevID", ElevID);
                SqlParameter paramMaterieID = new SqlParameter("@MaterieID", MaterieID);
                SqlParameter paramSemestruID = new SqlParameter("@SemestruID", SemestruID);
                cmd.Parameters.Add(paramElevID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramSemestruID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                ElevMaterie c = null;
                if (reader.Read())
                {
                    c = new ElevMaterie();
                    c.ElevMaterieID = reader.GetInt32(0);
                    c.ElevID = reader.GetInt32(2);
                    c.MaterieID = reader.GetInt32(1);
                    c.SemestruID = reader.GetInt32(3);
                    if (reader.IsDBNull(4)) c.Medie = null; else c.Medie = reader.GetDouble(4);

                }
                reader.Close();
                return c;
            }

        }
    }
}
