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
    public class SpecializareBL
    {
        private SpecializareDA specializareDA = new SpecializareDA();

        public void AddSpecializare(Specializare specializare)
        {
            specializareDA.AddSpecializare(specializare);
        }
        public void DeleteSpecializare(int? id)
        {
            specializareDA.DeleteSpecializare(id);
        }
        public ObservableCollection<string> GetSpecializariStringList()
        {

            ObservableCollection<Specializare> specializariList = specializareDA.GetSpecializari();
            ObservableCollection<string> specializari = new ObservableCollection<string>();
        
            foreach (Specializare spec in specializariList)
            {
                specializari.Add(spec.Nume + " " + spec.SpecializareID.ToString());
            }
            return specializari;
        }
    }
}
