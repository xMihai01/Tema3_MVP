using System;
using System.Collections.Generic;
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
            MessageBox.Show("OK " + mainVM.UserName + " " + mainVM.PersonType + " " + mainVM.PasswordText);
        }
    }
}
