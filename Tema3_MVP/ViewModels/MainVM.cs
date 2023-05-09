using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.ViewModels
{
    public class MainVM
    {
        public List<string> personType { get; set; } = new List<string> { "Elev", "Profesor", "Diriginte", "Administrator" };

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyPropertyChanged(nameof(UserName));
            }
        }
        private string _password;

        public string PasswordText
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(PasswordText));
            }
        }

        private string _personType;

        public string PersonType
        {
            get { return _personType; }
            set
            {
                _personType = value;
                NotifyPropertyChanged(nameof(PersonType));
            }
        }
        public MainVM()
        {
            PersonType = "Elev";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
