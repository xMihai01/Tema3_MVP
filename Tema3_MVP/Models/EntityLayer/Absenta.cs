using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_MVP.Models.EntityLayer
{
    public class Absenta
    {
        private int? _absentaID;

        public int? AbsentaID
        {
            get
            {
                return _absentaID;
            }
            set
            {
                _absentaID = value;
                NotifyPropertyChanged(nameof(AbsentaID));
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
