using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    class Elev
    {
        private int? _elevID;

        public int? ElevID
        {
            get
            {
                return _elevID;
            }
            set
            {
                _elevID = value;
                NotifyPropertyChanged(nameof(ElevID));
            }
        }
        private string _nume;

        public string Nume
        {
            get
            {
                return _nume;
            }
            set
            {
                _nume = value;
                NotifyPropertyChanged(nameof(Nume));
            }
        }
        private string _prenume;

        public string Prenume
        {
            get
            {
                return _prenume;
            }
            set
            {
                _prenume = value;
                NotifyPropertyChanged(nameof(Prenume));
            }
        }
        private int? _clasaID;
        public int? ClasaID
        {
            get
            {
                return _clasaID;
            }
            set
            {
                _clasaID = value;
                NotifyPropertyChanged(nameof(ClasaID));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
