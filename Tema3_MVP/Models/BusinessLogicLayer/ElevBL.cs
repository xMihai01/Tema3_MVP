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
    public class ElevBL
    {
        public ObservableCollection<Elev> listaElevi;


        ElevBL() {
            listaElevi = new ObservableCollection<Elev>();
            
        }

        public void AddElev(Elev elev)
        {
            ElevDA.AddElev(elev);
            listaElevi.Add(elev);
        }
        public void DeleteElev(int id)
        {
            ElevDA.DeleteElev(id);
            listaElevi.RemoveAt(id - 1);
        }
    }
}
