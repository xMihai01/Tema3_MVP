using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class ElevMaterie
    {
        private int? _ElevID;

        public int? ElevID
        {
            get
            {
                return _ElevID;
            }
            set
            {
                _ElevID = value;
                NotifyPropertyChanged(nameof(ElevID));
            }
        }
        private int? _MaterieID;
        public int? MaterieID
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
        private double? _Medie;
        public double? Medie
        {
            get
            {
                return _Medie;
            }
            set
            {
                _Medie = value;
                NotifyPropertyChanged(nameof(Medie));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ElevMaterie(int? elevID, int? materieID, int? semestruID)
        {
            ElevID = elevID;
            MaterieID = materieID;
            SemestruID = semestruID;
        }
        public ElevMaterie()
        {

        }
    }
}
