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

        public string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string _password;

        public string PasswordText
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(PasswordText));
            }
        }

        public string _personType;

        public string PersonType
        {
            get { return _personType; }
            set
            {
                _personType = value;
                OnPropertyChanged(nameof(PersonType));
            }
        }
        public MainVM()
        {
            PersonType = "Elev";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
