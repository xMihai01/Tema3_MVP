using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class ProfesorMaterieBL
    {
        private ProfesorMaterieDA profesorMaterieDA = new ProfesorMaterieDA();

        public void AddProfesorMaterie(ProfesorMaterie ProfesorMaterie)
        {
            profesorMaterieDA.AddProfesorMaterie(ProfesorMaterie);

        }
        public void DeleteProfesorMaterie(int id)
        {
            profesorMaterieDA.DeleteProfesorMaterie(id);
        }

        public ObservableCollection<string> GetProfesorMateriiStringListForProfesor(int? id_Profesor)
        {

            ObservableCollection<ProfesorMaterie> pmList = profesorMaterieDA.GetProfesorMaterii();
            ObservableCollection<string> pms = new ObservableCollection<string>();

            foreach (ProfesorMaterie pm in pmList)
            {
                if (pm.ProfesorID == id_Profesor)
                    pms.Add("ID: " + pm.ProfesorMaterieID + " | MaterieID: " + pm.MaterieID.ToString());
            }
            return pms;
        }
    }
}
