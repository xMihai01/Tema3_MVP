using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.ViewModels
{
    public class ProfesorAbsenteVM : INotifyPropertyChanged
    {
        private AbsentaBL absentaBL = new AbsentaBL();

        public Elev elev { get; set; }
        public Materie materie { get; set; }
        public Semestru semestru { get; set; }
        public string _labelInfoAbsente;
        public string LabelInfoAbsente
        {
            get { return _labelInfoAbsente; }
            set
            {
                _labelInfoAbsente = value;
                NotifyPropertyChanged(nameof(LabelInfoAbsente));
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

        private Absenta _selectedAbsenta;
        public Absenta SelectedAbsenta
        {
            get { return _selectedAbsenta; }
            set
            {
                _selectedAbsenta = value;
                NotifyPropertyChanged(nameof(SelectedAbsenta));
            }
        }
        public ICommand AddAbsentaButtonCommand => new RelayCommand(AddAbsentaButton);
        public void AddAbsentaButton()
        {
            absentaBL.AddAbsenta(elev.ElevID, materie.MaterieID, semestru.SemestruID);
            UpdateAbsente();
        }
        private void UpdateAbsente()
        {
            Absente = absentaBL.GetAbsente(elev.ElevID, materie.MaterieID, semestru.SemestruID);
        }
        public ProfesorAbsenteVM(Elev elev, Materie materie, Semestru semestru)
        {
            this.elev = elev;
            this.materie = materie;
            this.semestru = semestru;
            LabelInfoAbsente = "Viewing " + elev.Nume + " " + elev.Prenume + "'s absente for materie " + materie.Nume + ", semester: " + semestru.Nume;
            UpdateAbsente();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
