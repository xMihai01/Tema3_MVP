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
    public class SemestruBL
    {
        private SemestruDA SemestruDA = new SemestruDA();

        public void AddSemestru(Semestru Semestru)
        {
            SemestruDA.AddSemestru(Semestru);
        }
        public void DeleteSemestru(int? id)
        {
            SemestruDA.DeleteSemestru(id);
        }
        public ObservableCollection<Semestru> GetSemestre()
        {

            return SemestruDA.GetSemestre();
        }
        public ObservableCollection<string> GetSemestreAsStringList(bool requiresID = true)
        {

            ObservableCollection<Semestru> semList = SemestruDA.GetSemestre();
            ObservableCollection<string> semestre = new ObservableCollection<string>();

            foreach (Semestru sem in semList)
            {
                if (requiresID)
                    semestre.Add(sem.Nume + " " + sem.SemestruID.ToString());
                else
                    semestre.Add(sem.Nume);
            }
            return semestre;
        }

    }
}
