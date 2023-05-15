using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Materie
    {
        private int? _materieID;

        public int? MaterieID
        {
            get
            {
                return _materieID;
            }
            set
            {
                _materieID = value;
                NotifyPropertyChanged(nameof(MaterieID));
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public Materie(string nume)
        {
            Nume = nume;
        }
        public Materie()
        {

        }
    }
}
