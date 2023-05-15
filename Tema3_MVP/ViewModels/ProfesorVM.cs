using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Views;

namespace Tema3_MVP.ViewModels
{
    public class ProfesorVM : INotifyPropertyChanged
    {
        private int? ProfesorID;
        public ObservableCollection<string> _Classes;
        public ObservableCollection<string> Classes
        {
            get { return _Classes; }
            set
            {
                _Classes = value;
                NotifyPropertyChanged(nameof(Classes));
            }
        }
        private Dictionary<string, Clasa> clase = new Dictionary<string, Clasa>();
        private Dictionary<string, Materie> materiiDic = new Dictionary<string, Materie>();
        private Dictionary<string, Semestru> semestreDic = new Dictionary<string, Semestru>();
        private ClasaBL clasaBL = new ClasaBL();
        private ElevBL elevBL = new ElevBL();
        private MaterieBL materieBL = new MaterieBL();
        private SemestruBL semestruBL = new SemestruBL();
        private ElevMaterieBL elevMaterieBL = new ElevMaterieBL();

        private string _selectedClass;

        public string SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                NotifyPropertyChanged(nameof(SelectedClass));
                UpdateElevi();
                UpdateMaterii();
            }
        }
        private ObservableCollection<Elev> _elevi;
        public ObservableCollection<Elev> Elevi
        {
            get { return _elevi; }
            set
            {
                _elevi = value;
                NotifyPropertyChanged(nameof(Elevi));
            }
        }

        private Elev _selectedElev;
        public Elev SelectedElev
        {
            get { return _selectedElev; }
            set
            {
                _selectedElev = value;
                NotifyPropertyChanged(nameof(SelectedElev));
            }
        }
        public ObservableCollection<string> _Materii;
        public ObservableCollection<string> Materii
        {
            get { return _Materii; }
            set
            {
                _Materii = value;
                NotifyPropertyChanged(nameof(Materii));
            }
        }
        public string _selectedMaterie;
        public string SelectedMaterie
        {
            get { return _selectedMaterie; }
            set
            {
                _selectedMaterie = value;
                NotifyPropertyChanged(nameof(SelectedMaterie));
            }
        }

        private ObservableCollection<string> _Semestre;
        public ObservableCollection<string> Semestre
        {
            get { return _Semestre; }
            set
            {
                _Semestre = value;
                NotifyPropertyChanged(nameof(Semestre));
            }
        }

        private string _selectedSemestru;
        public string SelectedSemestru
        {
            get { return _selectedSemestru; }
            set
            {
                _selectedSemestru = value;
                NotifyPropertyChanged(nameof(SelectedSemestru));
            }
        }

        public void UpdateElevi()
        {
            Elevi = elevBL.GetEleviForClasa(clase[SelectedClass].ClasaID);
        }
        public void UpdateMaterii()
        {
            Materii = materieBL.GetMateriiForClasaAndProfesorStringList(clase[SelectedClass].ClasaID, ProfesorID);
            foreach (Materie mtr in materieBL.GetMateriiForClasaAndProfesor(clase[SelectedClass].ClasaID, ProfesorID))
                materiiDic[mtr.Nume] = mtr;
        }
        
        public ICommand ViewAbsenteButtonCommand => new RelayCommand(ViewAbsenteButton);
        public void ViewAbsenteButton()
        {
            if (SelectedElev == null || SelectedClass == null || SelectedMaterie == null || SelectedSemestru == null)
            {
                MessageBox.Show("You must select a clasa, materie, semestru and elev to continue");
                return;
            }
            elevMaterieBL.AddElevMaterie(new ElevMaterie(SelectedElev.ElevID, materiiDic[SelectedMaterie].MaterieID, semestreDic[SelectedSemestru].SemestruID));
            ProfesorAbsenteWindow profesorAbsenteWindow = new ProfesorAbsenteWindow(SelectedElev, materiiDic[SelectedMaterie], semestreDic[SelectedSemestru]);
            profesorAbsenteWindow.Show();

        }

        public ProfesorVM(int? profesorID)
        {
            ProfesorID = profesorID;
            Classes = clasaBL.GetClaseForProfesorAsStringList(profesorID);
            foreach (Clasa cls in clasaBL.GetClaseForProfesor(profesorID))
                clase[cls.Nume] = cls;
            Semestre = semestruBL.GetSemestreAsStringList(false);
            foreach (Semestru sm in semestruBL.GetSemestre())
                semestreDic[sm.Nume] = sm;
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
