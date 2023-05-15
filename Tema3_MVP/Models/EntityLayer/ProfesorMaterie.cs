using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class ProfesorMaterie
    {
        private int? _ProfesorID;

        public int? ProfesorID
        {
            get
            {
                return _ProfesorID;
            }
            set
            {
                _ProfesorID = value;
                NotifyPropertyChanged(nameof(ProfesorID));
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
        private int? _ProfesorMaterieID;
        public int? ProfesorMaterieID
        {
            get
            {
                return _ProfesorMaterieID;
            }
            set
            {
                _ProfesorMaterieID = value;
                NotifyPropertyChanged(nameof(ProfesorMaterieID));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ProfesorMaterie(int? profesorID, int materieID)
        {
            ProfesorID = profesorID;
            MaterieID = materieID;
        }
        public ProfesorMaterie()
        {

        }
    }
}
