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
using System.Security.Claims;

namespace Tema3_MVP.ViewModels
{
    public class ElevVM : INotifyPropertyChanged
    {
        private ElevBL elevBL = new ElevBL();
        private Elev elev;
        private Dictionary<string, Materie> materiiDic = new Dictionary<string, Materie>();
        private Dictionary<string, Semestru> semestreDic = new Dictionary<string, Semestru>();
        private MaterieBL materieBL = new MaterieBL();
        private SemestruBL semestruBL = new SemestruBL();
        private ElevMaterieBL elevMaterieBL = new ElevMaterieBL();
        private AbsentaBL absentaBL = new AbsentaBL();
        private NotaBL notaBL = new NotaBL();
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
                UpdateAbsente();
                UpdateNote();
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
                UpdateAbsente();
                UpdateNote();
            }
        }

        private ObservableCollection<Absenta> _Absente;
        public ObservableCollection<Absenta> Absente
        {
            get { return _Absente; }
            set
            {
                _Absente = value;
                NotifyPropertyChanged(nameof(Absente));
            }
        }
        private ObservableCollection<Nota> _Note;
        public ObservableCollection<Nota> Note
        {
            get { return _Note; }
            set
            {
                _Note = value;
                NotifyPropertyChanged(nameof(Note));
            }
        }
        private void UpdateAbsente()
        {
            if (SelectedSemestru != null && SelectedMaterie != null) 
                Absente = absentaBL.GetAbsente(elev.ElevID, materiiDic[SelectedMaterie].MaterieID, semestreDic[SelectedSemestru].SemestruID);
        }
        private void UpdateNote()
        {
            if (SelectedSemestru != null && SelectedMaterie != null)
                Note = notaBL.GetNote(elev.ElevID, materiiDic[SelectedMaterie].MaterieID, semestreDic[SelectedSemestru].SemestruID);
        }
        public ICommand StatsButtonCommand => new RelayCommand(StatsButton);
        public void StatsButton()
        {
            if (SelectedSemestru == null)
            {
                MessageBox.Show("Select a semestru first");
                return;
            }
            MessageBox.Show(elevMaterieBL.GetAllMediiMessage(elev.ElevID, semestreDic[SelectedSemestru].SemestruID, materieBL.GetMateriiForClasa(elev.ClasaID)));
        }

        public ElevVM(int? ElevID)
        {
            elev = elevBL.GetElev(ElevID);
            Semestre = semestruBL.GetSemestreAsStringList(false);
            foreach (Semestru sm in semestruBL.GetSemestre())
                semestreDic[sm.Nume] = sm;
            Materii = materieBL.GetMateriiForClasaStringList(elev.ClasaID);
            foreach (Materie mtr in materieBL.GetMateriiForClasa(elev.ClasaID))
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
