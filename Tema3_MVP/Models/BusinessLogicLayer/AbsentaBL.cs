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
    public class AbsentaBL
    {
        private AbsentaDA absentaDA = new AbsentaDA();
        public void AddAbsenta(int? ElevID, int? MaterieID, int? SemestruID)
        {
            absentaDA.AddAbsenta(ElevID, MaterieID, SemestruID);
        }
        public ObservableCollection<Absenta> GetAbsente(int? ElevID, int? MaterieID, int? SemestruID)
        {
            return absentaDA.GetAbsente(ElevID, MaterieID, SemestruID);
        }
    }
}
