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
    public class ProfesorBL
    {
        public ObservableCollection<Profesor> listaProfesori;
        private ProfesorDA ProfesorDA = new ProfesorDA();

        public ProfesorBL()
        {
            listaProfesori = new ObservableCollection<Profesor>();

        }

        public void AddProfesor(Profesor Profesor)
        {
            ProfesorDA.AddProfesor(Profesor);
            listaProfesori.Add(Profesor);
        }
        public void DeleteProfesor(Profesor Profesor)
        {
            ProfesorDA.DeleteProfesor(Profesor.ProfesorID);
            listaProfesori.Remove(Profesor);
        }
        public void UpdateProfesor(Profesor Profesor)
        {
            ProfesorDA.UpdateProfesor(Profesor);
            listaProfesori[listaProfesori.IndexOf(Profesor)] = Profesor;
        }
        public ObservableCollection<Profesor> GetProfesori()
        {
            listaProfesori = ProfesorDA.GetProfesori();
            return listaProfesori;
        }
    }
}
