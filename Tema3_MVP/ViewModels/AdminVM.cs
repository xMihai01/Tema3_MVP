using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3_MVP.Commands;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Views;

namespace Tema3_MVP.ViewModels
{
    public class AdminVM
    {
        public AdminVM()
        {
        }

        public ICommand AddElevButtonCommand => new RelayCommand(AddElevButton);
        public ICommand DeleteElevButtonCommand => new RelayCommand(DeleteElevButton);

        public void AddElevButton()
        {
            InputWindow inputDialog = new InputWindow("Please enter elev name: ", "Doloiu Mihai");
            if (inputDialog.ShowDialog() == true)
            {
                string[] dataElev = inputDialog.Answer.Split(' ');
                if (dataElev.Count() > 1)
                {
                    ElevDA.AddElev(new Elev(dataElev[0], dataElev[1]));
                    MessageBox.Show("Success! Elev added!");
                }
                else
                    MessageBox.Show("Failed, you must enter a full name!");

            }
        }
        public void DeleteElevButton()
        {

        }
    }
}
