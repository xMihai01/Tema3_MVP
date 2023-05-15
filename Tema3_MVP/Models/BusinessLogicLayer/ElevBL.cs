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
        private ElevDA elevDA = new ElevDA();

        public ElevBL() {
            listaElevi = new ObservableCollection<Elev>();
            
        }

        public void AddElev(Elev elev)
        {
            elevDA.AddElev(elev);
            listaElevi.Add(elev);
        }
        public void DeleteElev(Elev elev)
        {
            elevDA.DeleteElev(elev.ElevID);
            listaElevi.Remove(elev);
        }
        public void UpdateElev(Elev elev)
        {
            elevDA.UpdateElev(elev);
            listaElevi[listaElevi.IndexOf(elev)] = elev;
        }
        public ObservableCollection<Elev> GetElevi()
        {
            listaElevi = elevDA.GetElevi();
            return listaElevi;
        }
        public ObservableCollection<Elev> GetEleviForClasa(int? ClasaID)
        {
            return elevDA.GetEleviForClasa(ClasaID);
        }
    }
}
