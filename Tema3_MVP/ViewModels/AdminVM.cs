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
    public class AdminVM : INotifyPropertyChanged
    {
        private ElevBL elevBL = new ElevBL();
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
                NotifyPropertyChanged(nameof(SelectedElev));}
        }
        private ProfesorBL ProfesorBL = new ProfesorBL();
        private ObservableCollection<Profesor> _Profesori;
        public ObservableCollection<Profesor> Profesori
        {
            get { return _Profesori; }
            set
            {
                _Profesori = value;
                NotifyPropertyChanged(nameof(Profesori));
            }
        }

        private Profesor _selectedProfesor;
        public Profesor SelectedProfesor
        {
            get { return _selectedProfesor; }
            set
            {
                _selectedProfesor = value;
                NotifyPropertyChanged(nameof(SelectedProfesor));
            }
        }

        public AdminVM()
        {
            Elevi = elevBL.GetElevi();
        }
        public void UpdateElevi()
        {
            Elevi = elevBL.GetElevi();
        }
        public void UpdateProfesori()
        {
            Profesori = ProfesorBL.GetProfesori();
        }

        public ICommand AddElevButtonCommand => new RelayCommand(AddElevButton);
        public ICommand DeleteElevButtonCommand => new RelayCommand(DeleteElevButton);
        public ICommand UpdateElevButtonCommand => new RelayCommand(UpdateElevButton);

        public void AddElevButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter elev name: ", "Doloiu Mihai");
            if (inputDialog.ShowDialog() == true)
            {
                string[] dataElev = inputDialog.Answer.Split(' ');
                if (dataElev.Count() > 1)
                {
                    elevBL.AddElev(new Elev(dataElev[0], dataElev[1]));
                    MessageBox.Show("Success! Elev added!");
                }
                else
                    MessageBox.Show("Failed, you must enter a full name!");

            }
            UpdateElevi();
        }
        public void DeleteElevButton()
        {
            elevBL.DeleteElev(SelectedElev);
            UpdateElevi();
        }

        public void UpdateElevButton()
        {
            elevBL.UpdateElev(SelectedElev);
            UpdateElevi();
        }

        public ICommand AddProfesorButtonCommand => new RelayCommand(AddProfesorButton);
        public ICommand DeleteProfesorButtonCommand => new RelayCommand(DeleteProfesorButton);
        public ICommand UpdateProfesorButtonCommand => new RelayCommand(UpdateProfesorButton);

        public void AddProfesorButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Profesor name: ", "Doloiu Mihai");
            if (inputDialog.ShowDialog() == true)
            {
                string[] dataProfesor = inputDialog.Answer.Split(' ');
                if (dataProfesor.Count() > 1)
                {
                    ProfesorBL.AddProfesor(new Profesor(dataProfesor[0], dataProfesor[1]));
                    MessageBox.Show("Success! Profesor added!");
                }
                else
                    MessageBox.Show("Failed, you must enter a full name!");

            }
            UpdateProfesori();
        }
        public void DeleteProfesorButton()
        {
            ProfesorBL.DeleteProfesor(SelectedProfesor);
            UpdateProfesori();
        }

        public void UpdateProfesorButton()
        {
            ProfesorBL.UpdateProfesor(SelectedProfesor);
            UpdateProfesori();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
