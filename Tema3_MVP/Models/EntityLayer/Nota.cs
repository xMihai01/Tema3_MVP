using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Nota
    {
        private int? _notaID;

        public int? NotaID
        {
            get
            {
                return _notaID;
            }
            set
            {
                _notaID = value;
                NotifyPropertyChanged(nameof(NotaID));
            }
        }
        private int? _ElevMaterieID;

        public int? ElevMaterieID
        {
            get
            {
                return _ElevMaterieID;
            }
            set
            {
                _ElevMaterieID = value;
                NotifyPropertyChanged(nameof(ElevMaterieID));
            }
        }

        private string _tip;

        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
                NotifyPropertyChanged(nameof(Tip));
            }
        }

        private double? _valoareNota;

        public double? ValoareNota
        {
            get
            {
                return _valoareNota;
            }
            set
            {
                _valoareNota = value;
                NotifyPropertyChanged(nameof(ValoareNota));
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged(nameof(Date));
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
