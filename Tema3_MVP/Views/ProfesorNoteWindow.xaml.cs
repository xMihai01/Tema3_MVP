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
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Views
{
    /// <summary>
    /// Interaction logic for ProfesorNoteWindow.xaml
    /// </summary>
    public partial class ProfesorNoteWindow : Window
    {
        public ProfesorNoteVM profesorNoteVM;
        public ProfesorNoteWindow(Elev elev, Materie materie, Semestru semestru)
        {
            InitializeComponent();
            profesorNoteVM = new ProfesorNoteVM(elev, materie, semestru);
            DataContext = profesorNoteVM;
        }
    }
}
