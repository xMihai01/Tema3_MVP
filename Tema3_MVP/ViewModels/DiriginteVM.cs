using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Views;
using Tema3_MVP.Models.DataAccessLayer;

namespace Tema3_MVP.ViewModels
{
    public class DiriginteVM : INotifyPropertyChanged
    {
        private Clasa clasa;
        
        private Dictionary<string, Materie> materiiDic = new Dictionary<string, Materie>();
        private Dictionary<string, Semestru> semestreDic = new Dictionary<string, Semestru>();
        private ClasaBL clasaBL = new ClasaBL();
        private ElevBL elevBL = new ElevBL();
        private MaterieBL materieBL = new MaterieBL();
        private SemestruBL semestruBL = new SemestruBL();
        private ElevMaterieBL elevMaterieBL = new ElevMaterieBL();
        private AbsentaBL absentaBL = new AbsentaBL();
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
            Elevi = elevBL.GetEleviForClasa(clasa.ClasaID);
        }

        public ICommand ViewAbsenteButtonCommand => new RelayCommand(ViewAbsenteButton);
        public ICommand ViewMediiElevButtonCommand => new RelayCommand(ViewMediiElevButton);
        public ICommand ViewTopMediiButtonCommand => new RelayCommand(ViewTopMediiButton);
        public ICommand ViewStatsButtonCommand => new RelayCommand(ViewStatsButton);
        public ICommand ViewKickedButtonCommand => new RelayCommand(ViewKickedButton);
        public void ViewAbsenteButton()
        {
            if (SelectedElev == null || SelectedMaterie == null || SelectedSemestru == null)
            {
                MessageBox.Show("You must select a materie, semestru and elev to continue");
                return;
            }
            elevMaterieBL.AddElevMaterie(new ElevMaterie(SelectedElev.ElevID, materiiDic[SelectedMaterie].MaterieID, semestreDic[SelectedSemestru].SemestruID));
            ProfesorAbsenteWindow profesorAbsenteWindow = new ProfesorAbsenteWindow(SelectedElev, materiiDic[SelectedMaterie], semestreDic[SelectedSemestru], false);
            profesorAbsenteWindow.Show();

        }
        public void ViewMediiElevButton()
        {
            if (SelectedElev == null || SelectedSemestru == null)
            {
                MessageBox.Show("You must select a semestru and an elev to continue");
                return;
            }
            MessageBox.Show(elevMaterieBL.GetAllMediiMessage(SelectedElev.ElevID, semestreDic[SelectedSemestru].SemestruID, materieBL.GetMateriiForClasa(clasa.ClasaID)));

        }
        public void ViewTopMediiButton()
        {
            if (SelectedSemestru == null)
            {
                MessageBox.Show("Select a semestru first");
                return;
            }
            MessageBox.Show(elevMaterieBL.GetTopMediiMessage(semestreDic[SelectedSemestru].SemestruID, materieBL.GetMateriiForClasa(clasa.ClasaID), Elevi));
        }
        public void ViewStatsButton()
        {
            if (SelectedSemestru == null)
            {
                MessageBox.Show("Select a semestru first");
                return;
            }
            var tuple = elevMaterieBL.GetStatsMessage(semestreDic[SelectedSemestru].SemestruID, materieBL.GetMateriiForClasa(clasa.ClasaID), Elevi);
            if (tuple == null)
            {
                MessageBox.Show("No average found for some elevi");
                return;
            }
            MessageBox.Show(tuple.Item1);
            MessageBox.Show(tuple.Item2);
            MessageBox.Show(tuple.Item3);
        }
        public void ViewKickedButton()
        {
            if (SelectedSemestru == null)
            {
                MessageBox.Show("Select a semestru first");
                return;
            }
            MessageBox.Show(absentaBL.GetKickedEleviMessage(Elevi, semestreDic[SelectedSemestru].SemestruID));
        }
        public DiriginteVM(int? profesorID)
        {
            clasa = clasaBL.GetClasa(profesorID);
            Semestre = semestruBL.GetSemestreAsStringList(false);
            foreach (Semestru sm in semestruBL.GetSemestre())
                semestreDic[sm.Nume] = sm;
            Elevi = elevBL.GetEleviForClasa(clasa.ClasaID);
            Materii = materieBL.GetMateriiForClasaStringList(clasa.ClasaID);
            foreach (Materie mtr in materieBL.GetMateriiForClasa(clasa.ClasaID))
                materiiDic[mtr.Nume] = mtr;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
