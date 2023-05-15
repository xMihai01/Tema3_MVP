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
    public class ClasaMaterieBL
    {
        private ClasaMaterieDA ClasaMaterieDA = new ClasaMaterieDA();

        public void AddClasaMaterie(ClasaMaterie ClasaMaterie)
        {
            ClasaMaterieDA.AddClasaMaterie(ClasaMaterie);
         
        }
        public void DeleteClasaMaterie(int id)
        {
            ClasaMaterieDA.DeleteClasaMaterie(id);
        }

        public ObservableCollection<string> GetClaseMateriiStringListForClasa(int? id_clasa)
        {

            ObservableCollection<ClasaMaterie> cmList = ClasaMaterieDA.GetClaseMaterii();
            ObservableCollection<string> cms = new ObservableCollection<string>();

            foreach (ClasaMaterie cm in cmList)
            {
                if (cm.ClasaID == id_clasa)
                    cms.Add("ID: " + cm.ClasaMaterieID + " | ClassID: " + cm.ClasaID.ToString() + " | MaterieID: " + cm.MaterieID.ToString() + " | Teza " + cm.Teza);
            }
            return cms;
        }
    }
}
