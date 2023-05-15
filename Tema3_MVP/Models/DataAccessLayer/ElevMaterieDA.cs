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
    }
}
