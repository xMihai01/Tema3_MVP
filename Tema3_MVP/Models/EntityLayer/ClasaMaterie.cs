using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class ClasaMaterie
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
        private int _MaterieID;
        public int MaterieID
        {
            get
            {
                return _MaterieID;
            }
            set
            {
                _MaterieID = value;
                NotifyPropertyChanged(nameof(MaterieID));
            }
        }
        private int? _ClasaMaterieID;
        public int? ClasaMaterieID
        {
            get
            {
                return _ClasaMaterieID;
            }
            set
            {
                _ClasaMaterieID = value;
                NotifyPropertyChanged(nameof(ClasaMaterieID));
            }
        }
        private bool _teza;
        public bool Teza
        {
            get
            {
                return _teza;
            }
            set
            {
                _teza = value;
                NotifyPropertyChanged(nameof(Teza));
            }
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ClasaMaterie(int? clasaID, int materieID, bool teza)
        {
            ClasaID = clasaID;
            MaterieID = materieID;
            Teza = teza;
        }
        public ClasaMaterie()
        {

        }
    }
}
