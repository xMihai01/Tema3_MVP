using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Semestru
    {
        private int? _SemestruID;

        public int? SemestruID
        {
            get
            {
                return _SemestruID;
            }
            set
            {
                _SemestruID = value;
                NotifyPropertyChanged(nameof(SemestruID));
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
        public Semestru(string nume)
        {
            Nume = nume;
        }
        public Semestru()
        {

        }
    }
}
