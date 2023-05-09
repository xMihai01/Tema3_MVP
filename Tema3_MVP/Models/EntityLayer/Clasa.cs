using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Clasa
    {
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
        private int? _diriginteID;
        public int? DiriginteID
        {
            get
            {
                return _diriginteID;
            }
            set
            {
                _diriginteID = value;
                NotifyPropertyChanged(nameof(DiriginteID));
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
        private string _specializare;
        public string Specializare
        {
            get
            {
                return _specializare;
            }
            set
            {
                _specializare = value;
                NotifyPropertyChanged(nameof(Specializare));
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
