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
    public class MaterieBL
    {
        private MaterieDA MaterieDA = new MaterieDA();

        public void AddMaterie(Materie Materie)
        {
            MaterieDA.AddMaterie(Materie);
        }
        public void DeleteMaterie(int? id)
        {
            MaterieDA.DeleteMaterie(id);
        }
        public ObservableCollection<string> GetMateriiStringList()
        {

            ObservableCollection<Materie> materiiList = MaterieDA.GetSpecializari();
            ObservableCollection<string> materii = new ObservableCollection<string>();

            foreach (Materie mat in materiiList)
            {
                materii.Add(mat.Nume + " " + mat.MaterieID.ToString());
            }
            return materii;
        }
    }
}
