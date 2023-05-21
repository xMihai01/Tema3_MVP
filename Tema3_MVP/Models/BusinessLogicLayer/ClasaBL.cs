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
    public class ClasaBL
    {
        public ObservableCollection<Clasa> listaClase;
        private ClasaDA ClasaDA = new ClasaDA();

        public ClasaBL()
        {
            listaClase = new ObservableCollection<Clasa>();

        }

        public void AddClasa(Clasa Clasa)
        {
            ClasaDA.AddClasa(Clasa);
            listaClase.Add(Clasa);
        }
        public void DeleteClasa(Clasa Clasa)
        {
            ClasaDA.DeleteClasa(Clasa.ClasaID);
            listaClase.Remove(Clasa);
        }
        public void UpdateClasa(Clasa Clasa)
        {
            ClasaDA.UpdateClasa(Clasa);
            listaClase[listaClase.IndexOf(Clasa)] = Clasa;
        }
        public ObservableCollection<Clasa> GetClase()
        {
            listaClase = ClasaDA.GetClase();
            return listaClase;
        }
        public ObservableCollection<Clasa> GetClaseForProfesor(int? ProfesorID)
        {
            return ClasaDA.GetClaseForProfesor(ProfesorID);
        }
        public ObservableCollection<string> GetClaseForProfesorAsStringList(int? ProfesorID)
        {

            ObservableCollection<Clasa> claseList = ClasaDA.GetClaseForProfesor(ProfesorID);
            ObservableCollection<string> clase = new ObservableCollection<string>();

            foreach (Clasa cls in claseList)
            {
                clase.Add(cls.Nume);
            }
            return clase;

        }
        public Clasa GetClasa(int? ProfesorID)
        {
            return ClasaDA.GetClasa(ProfesorID);
        }
    }
}
