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
    public class AdminVM : INotifyPropertyChanged
    {
        private ElevBL elevBL = new ElevBL();
        private ObservableCollection<Elev> _elevi;
        public ObservableCollection<Elev> Elevi
        {
            get { return _elevi; }
            set
            {
                _elevi = value;
                NotifyPropertyChanged(nameof(Elevi));
            }
        }

        private Elev _selectedElev;
        public Elev SelectedElev
        {
            get { return _selectedElev; }
            set 
            { 
                _selectedElev = value;
                NotifyPropertyChanged(nameof(SelectedElev));}
        }
        private ProfesorBL ProfesorBL = new ProfesorBL();
        private ObservableCollection<Profesor> _Profesori;
        public ObservableCollection<Profesor> Profesori
        {
            get { return _Profesori; }
            set
            {
                _Profesori = value;
                NotifyPropertyChanged(nameof(Profesori));
            }
        }

        private Profesor _selectedProfesor;
        public Profesor SelectedProfesor
        {
            get { return _selectedProfesor; }
            set
            {
                _selectedProfesor = value;
                NotifyPropertyChanged(nameof(SelectedProfesor));
            }
        }

        private ClasaBL clasaBL = new ClasaBL();
        private ObservableCollection<Clasa> _clase;
        public ObservableCollection<Clasa> Clase
        {
            get { return _clase; }
            set
            {
                _clase = value;
                NotifyPropertyChanged(nameof(Clase));
            }
        }

        private Clasa _selectedClasa;
        public Clasa SelectedClasa
        {
            get { return _selectedClasa; }
            set
            {
                _selectedClasa = value;
                NotifyPropertyChanged(nameof(SelectedClasa));
            }
        }

        private SpecializareBL specializareBL = new SpecializareBL();
        private MaterieBL materieBL = new MaterieBL();
        private ClasaMaterieBL clasaMaterieBL = new ClasaMaterieBL();
        private ProfesorMaterieBL profesorMaterieBL = new ProfesorMaterieBL();
        private SemestruBL semestruBL= new SemestruBL();

        public AdminVM()
        {
            Elevi = elevBL.GetElevi();
            Profesori = ProfesorBL.GetProfesori();
            Clase = clasaBL.GetClase();
        }
        public void UpdateElevi()
        {
            Elevi = elevBL.GetElevi();
        }
        public void UpdateProfesori()
        {
            Profesori = ProfesorBL.GetProfesori();
        }
        public void UpdateClase()
        {
            Clase = clasaBL.GetClase();
        }

        public ICommand AddElevButtonCommand => new RelayCommand(AddElevButton);
        public ICommand DeleteElevButtonCommand => new RelayCommand(DeleteElevButton);
        public ICommand UpdateElevButtonCommand => new RelayCommand(UpdateElevButton);

        public void AddElevButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter elev name: ", "Doloiu Mihai");
            if (inputDialog.ShowDialog() == true)
            {
                string[] dataElev = inputDialog.Answer.Split(' ');
                if (dataElev.Count() > 1)
                {
                    elevBL.AddElev(new Elev(dataElev[0], dataElev[1]));
                    MessageBox.Show("Success! Elev added!");
                }
                else
                    MessageBox.Show("Failed, you must enter a full name!");

            }
            UpdateElevi();
        }
        public void DeleteElevButton()
        {
            elevBL.DeleteElev(SelectedElev);
            UpdateElevi();
        }

        public void UpdateElevButton()
        {
            elevBL.UpdateElev(SelectedElev);
            UpdateElevi();
        }

        public ICommand AddProfesorButtonCommand => new RelayCommand(AddProfesorButton);
        public ICommand DeleteProfesorButtonCommand => new RelayCommand(DeleteProfesorButton);
        public ICommand UpdateProfesorButtonCommand => new RelayCommand(UpdateProfesorButton);

        public void AddProfesorButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Profesor name: ", "Doloiu Mihai");
            if (inputDialog.ShowDialog() == true)
            {
                string[] dataProfesor = inputDialog.Answer.Split(' ');
                if (dataProfesor.Count() > 1)
                {
                    ProfesorBL.AddProfesor(new Profesor(dataProfesor[0], dataProfesor[1]));
                    MessageBox.Show("Success! Profesor added!");
                }
                else
                    MessageBox.Show("Failed, you must enter a full name!");

            }
            UpdateProfesori();
        }
        public void DeleteProfesorButton()
        {
            ProfesorBL.DeleteProfesor(SelectedProfesor);
            UpdateProfesori();
        }

        public void UpdateProfesorButton()
        {
            ProfesorBL.UpdateProfesor(SelectedProfesor);
            UpdateProfesori();
        }

        public ICommand AddClasaButtonCommand => new RelayCommand(AddClasaButton);
        public ICommand DeleteClasaButtonCommand => new RelayCommand(DeleteClasaButton);
        public ICommand UpdateClasaButtonCommand => new RelayCommand(UpdateClasaButton);

        public void AddClasaButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Clasa name: ", "11B");
            if (inputDialog.ShowDialog() == true)
            {

                clasaBL.AddClasa(new Clasa(inputDialog.Answer));
                MessageBox.Show("Success! Clasa added!");
            }
            UpdateClase();
        }
        public void DeleteClasaButton()
        {
            clasaBL.DeleteClasa(SelectedClasa);
            UpdateClase();
        }

        public void UpdateClasaButton()
        {
            clasaBL.UpdateClasa(SelectedClasa);
            UpdateClase();
        }

        public ICommand AddSpecializareButtonCommand => new RelayCommand(AddSpecializareButton);
        public ICommand DeleteSpecializareButtonCommand => new RelayCommand(DeleteSpecializareButton);

        public void AddSpecializareButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Specializare name: ", "info aplicata", specializareBL.GetSpecializariStringList());
            if (inputDialog.ShowDialog() == true)
            {
                specializareBL.AddSpecializare(new Specializare(inputDialog.Answer));
                MessageBox.Show("Success! Specializare added!");
            }
        }
        public void DeleteSpecializareButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Specializare ID: ", "0", specializareBL.GetSpecializariStringList());
            if (inputDialog.ShowDialog() == true)
            {
                try
                {
                    specializareBL.DeleteSpecializare(Int32.Parse(inputDialog.Answer));
                    MessageBox.Show("Success! Specializare with id " + inputDialog.Answer + " removed!");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public ICommand AddMaterieButtonCommand => new RelayCommand(AddMaterieButton);
        public ICommand DeleteMaterieButtonCommand => new RelayCommand(DeleteMaterieButton);

        public void AddMaterieButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Materie name: ", "MVP", materieBL.GetMateriiStringList());
            if (inputDialog.ShowDialog() == true)
            {
                materieBL.AddMaterie(new Materie(inputDialog.Answer));
                MessageBox.Show("Materie added!");
            }
        }
        public void DeleteMaterieButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Materie ID: ", "0", materieBL.GetMateriiStringList());
            if (inputDialog.ShowDialog() == true)
            {
                try
                {
                    materieBL.DeleteMaterie(Int32.Parse(inputDialog.Answer));
                    MessageBox.Show("Materie with id " + inputDialog.Answer + " removed!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public ICommand AddMaterieToClasaButtonCommand => new RelayCommand(AddMaterieToClasaButton);
        public ICommand DeleteMaterieFromClasaButtonCommand => new RelayCommand(DeleteMaterieFromClasaButton);

        public void AddMaterieToClasaButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Materie ID: ", "0", materieBL.GetMateriiStringList());
            InputWindow inputDialogTeza = new InputWindow("Teza? (true/false): ", "false");
            if (inputDialog.ShowDialog() == true)
            {
                if (inputDialogTeza.ShowDialog() == true)
                {
                    try
                    {
                        clasaMaterieBL.AddClasaMaterie(new ClasaMaterie(SelectedClasa.ClasaID, Int32.Parse(inputDialog.Answer), Boolean.Parse(inputDialogTeza.Answer)));
                        MessageBox.Show("Clasa with id " + SelectedClasa.ClasaID + " now has a new Materie with id " + inputDialog.Answer + " with teza: " + inputDialogTeza.Answer);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
        }
        public void DeleteMaterieFromClasaButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter ID to remove: ", "0", clasaMaterieBL.GetClaseMateriiStringListForClasa(SelectedClasa.ClasaID));
            if (inputDialog.ShowDialog() == true)
            {
                try
                {
                    clasaMaterieBL.DeleteClasaMaterie(Int32.Parse(inputDialog.Answer));
                    MessageBox.Show("ClasaMaterie with id " + inputDialog.Answer + " removed!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public ICommand AddMaterieToProfesorButtonCommand => new RelayCommand(AddMaterieToProfesorButton);
        public ICommand DeleteMaterieFromProfesorButtonCommand => new RelayCommand(DeleteMaterieFromProfesorButton);

        public void AddMaterieToProfesorButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Materie ID: ", "0", materieBL.GetMateriiStringList());
            if (inputDialog.ShowDialog() == true)
            {

                try
                {
                    profesorMaterieBL.AddProfesorMaterie(new ProfesorMaterie(SelectedProfesor.ProfesorID, Int32.Parse(inputDialog.Answer)));
                    MessageBox.Show("Profesor with id " + SelectedProfesor.ProfesorID + " now has a new Materie with id " + inputDialog.Answer );
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());

                }
            }
        }
        public void DeleteMaterieFromProfesorButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter ID to remove: ", "0", profesorMaterieBL.GetProfesorMateriiStringListForProfesor(SelectedProfesor.ProfesorID));
            if (inputDialog.ShowDialog() == true)
            {
                try
                {
                    profesorMaterieBL.DeleteProfesorMaterie(Int32.Parse(inputDialog.Answer));
                    MessageBox.Show("ProfesorMaterie with id " + inputDialog.Answer + " removed!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public ICommand AddSemestruButtonCommand => new RelayCommand(AddSemestruButton);
        public ICommand DeleteSemestruButtonCommand => new RelayCommand(DeleteSemestruButton);

        public void AddSemestruButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Semestru name: ", "Semestrul 2 2023", semestruBL.GetSemestreAsStringList());
            if (inputDialog.ShowDialog() == true)
            {
                semestruBL.AddSemestru(new Semestru(inputDialog.Answer));
                MessageBox.Show("Success! Semestru added!");
            }
        }
        public void DeleteSemestruButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter Semestru ID: ", "0", semestruBL.GetSemestreAsStringList());
            if (inputDialog.ShowDialog() == true)
            {
                try
                {
                    semestruBL.DeleteSemestru(Int32.Parse(inputDialog.Answer));
                    MessageBox.Show("Success! Semestru with id " + inputDialog.Answer + " removed!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
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
