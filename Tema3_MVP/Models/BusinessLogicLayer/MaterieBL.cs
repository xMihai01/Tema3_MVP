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

            ObservableCollection<Materie> materiiList = MaterieDA.GetMaterii();
            ObservableCollection<string> materii = new ObservableCollection<string>();

            foreach (Materie mat in materiiList)
            {
                materii.Add(mat.Nume + " " + mat.MaterieID.ToString());
            }
            return materii;
        }
        public ObservableCollection<Materie> GetMateriiForClasaAndProfesor(int? ClasaID, int? ProfesorID)
        {
            return MaterieDA.GetMateriiForClasaAndProfesor(ClasaID, ProfesorID);
        }
        public ObservableCollection<string> GetMateriiForClasaAndProfesorStringList(int? ClasaID, int? ProfesorID)
        {

            ObservableCollection<Materie> materiiList = MaterieDA.GetMateriiForClasaAndProfesor(ClasaID, ProfesorID);
            ObservableCollection<string> materii = new ObservableCollection<string>();

            foreach (Materie mat in materiiList)
            {
                materii.Add(mat.Nume);
            }
            return materii;
        }
        public ObservableCollection<Materie> GetMateriiForClasa(int? ClasaID)
        {
            return MaterieDA.GetMateriiForClasa(ClasaID);
        }
        public ObservableCollection<string> GetMateriiForClasaStringList(int? ClasaID)
        {

            ObservableCollection<Materie> materiiList = MaterieDA.GetMateriiForClasa(ClasaID);
            ObservableCollection<string> materii = new ObservableCollection<string>();

            foreach (Materie mat in materiiList)
            {
                materii.Add(mat.Nume);
            }
            return materii;
        }
    }
}
