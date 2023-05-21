using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Views;

namespace Tema3_MVP.ViewModels
{
    public class ProfesorNoteVM : INotifyPropertyChanged
    {
        private NotaBL NotaBL = new NotaBL();
        private ClasaMaterieBL ClasaMaterieBL = new ClasaMaterieBL();

        public Elev elev { get; set; }
        public Materie materie { get; set; }
        public Semestru semestru { get; set; }
        public string _labelInfoNote;
        public string LabelInfoNote
        {
            get { return _labelInfoNote; }
            set
            {
                _labelInfoNote = value;
                NotifyPropertyChanged(nameof(LabelInfoNote));
            }
        }
        public string _labelInfoMedie;
        public string LabelInfoMedie
        {
            get { return _labelInfoMedie; }
            set
            {
                _labelInfoMedie = value;
                NotifyPropertyChanged(nameof(LabelInfoMedie));
            }
        }
        private ObservableCollection<Nota> _Note;
        public ObservableCollection<Nota> Note
        {
            get { return _Note; }
            set
            {
                _Note = value;
                NotifyPropertyChanged(nameof(Note));
            }
        }

        private Nota _selectedNota;
        public Nota SelectedNota
        {
            get { return _selectedNota; }
            set
            {
                _selectedNota = value;
                NotifyPropertyChanged(nameof(SelectedNota));
            }
        }
        public ICommand AddNotaButtonCommand => new RelayCommand(AddNotaButton);
        public ICommand DeleteNotaButtonCommand => new RelayCommand(DeleteNotaButton);
        public ICommand CalculateMedieButtonCommand => new RelayCommand(CalculateMedieButton);

        public void AddNotaButton()
        {
            if (!(NotaBL.GetMedie(elev.ElevID, materie.MaterieID, semestru.SemestruID) == null))
            {
                MessageBox.Show("Nota can't be added. Medie is already calculated");
                return;
            }
            InputWindow inputDialog = new InputWindow("Please enter new Nota: ", "10.0");
            InputWindow inputDialogTeza = new InputWindow("Teza? (true/false): ", "false");
            if (inputDialog.ShowDialog() == true)
            {
                if (ClasaMaterieBL.IsTezaRequired(elev.ClasaID, materie.MaterieID))
                {
                    if (inputDialogTeza.ShowDialog() == true)
                    {
                        try
                        {
                            if (Double.Parse(inputDialog.Answer) < 0 || Double.Parse(inputDialog.Answer) > 10) throw new Exception("Invalid nota");
                            NotaBL.AddNota(elev.ElevID, materie.MaterieID, semestru.SemestruID, Double.Parse(inputDialog.Answer), Boolean.Parse(inputDialogTeza.Answer));
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    }
                } else
                {
                    try
                    {
                        if (Double.Parse(inputDialog.Answer) < 0 || Double.Parse(inputDialog.Answer) > 10) throw new Exception("Invalid nota");
                        NotaBL.AddNota(elev.ElevID, materie.MaterieID, semestru.SemestruID, Double.Parse(inputDialog.Answer), false);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
            UpdateNote();
        }
        public void DeleteNotaButton()
        {
            if (NotaBL.GetMedie(elev.ElevID, materie.MaterieID, semestru.SemestruID) == null)
                NotaBL.DeleteNota(SelectedNota.NotaID);
            else MessageBox.Show("Nota can't be cancelled. Medie is already calculated");
            UpdateNote();
        }
        public void CalculateMedieButton()
        {
            NotaBL.CalculateMedie(elev.ElevID, materie.MaterieID, semestru.SemestruID, ClasaMaterieBL.IsTezaRequired(elev.ClasaID, materie.MaterieID));
            UpdateMedie();
        }
        private void UpdateNote()
        {
            Note = NotaBL.GetNote(elev.ElevID, materie.MaterieID, semestru.SemestruID);
        }
        private void UpdateMedie()
        {
            double? medie = NotaBL.GetMedie(elev.ElevID, materie.MaterieID, semestru.SemestruID);
            if (medie != null)
                LabelInfoMedie = "Medie: " + medie.ToString();
            else
                LabelInfoMedie = "Medie: N/A";
        }
        public ProfesorNoteVM(Elev elev, Materie materie, Semestru semestru)
        {
            this.elev = elev;
            this.materie = materie;
            this.semestru = semestru;
            LabelInfoNote = "Viewing " + elev.Nume + " " + elev.Prenume + "'s Note\n for materie " + materie.Nume + ", semester: " + semestru.Nume;
            double? medie = NotaBL.GetMedie(elev.ElevID, materie.MaterieID, semestru.SemestruID);
            LabelInfoMedie = "Medie: " + (medie == null ? "N/A" : medie.ToString());
            UpdateNote();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
