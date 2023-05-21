using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tema3_MVP.Models.BusinessLogicLayer;
using Tema3_MVP.Utils;
using Tema3_MVP.ViewModels;
namespace Tema3_MVP.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainVM mainVM;
        public MainWindow()
        {
            InitializeComponent();
            mainVM = new MainVM();
            DataContext = mainVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                try
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Connection failed.");
                        return;
                    }
                }
                catch (SqlException) { }
            }
            if (mainVM.PersonType == "Administrator")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
              
                this.Close();
            }
            if (mainVM.PersonType == "Profesor")
            {
                try
                {
                    ProfesorBL pbl = new ProfesorBL();
                    if (!pbl.DoesProfesorExist(Int32.Parse(mainVM.UserName)))
                        throw new Exception("You must enter a valid ID!");
                    ProfesorWindow profesorWindow = new ProfesorWindow(Int32.Parse(mainVM.UserName));
                    profesorWindow.Show();
                    this.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (mainVM.PersonType == "Diriginte")
            {
                try
                {
                    ClasaBL pbl = new ClasaBL();
                    if (pbl.GetClasa(Int32.Parse(mainVM.UserName)) == null)
                        throw new Exception("You must enter a valid ID!");
                    DiriginteWindow DiriginteWindow = new DiriginteWindow(Int32.Parse(mainVM.UserName));
                    DiriginteWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (mainVM.PersonType == "Elev")
            {
                try
                {
                    ElevBL pbl = new ElevBL();
                    if (pbl.GetElev(Int32.Parse(mainVM.UserName)) == null)
                        throw new Exception("You must enter a valid ID!");
                    ElevWindow elevWindow = new ElevWindow(Int32.Parse(mainVM.UserName));
                    elevWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
      
    }
}
