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

        public AdminVM()
        {
            Elevi = elevBL.GetElevi();
        }
        public void UpdateElevi()
        {
            Elevi = elevBL.GetElevi();
        }

        public ICommand AddElevButtonCommand => new RelayCommand(AddElevButton);
        public ICommand DeleteElevButtonCommand => new RelayCommand(DeleteElevButton);

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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
