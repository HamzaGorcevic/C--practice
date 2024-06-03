using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connecting_XAML_C_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         Student student= new Student
        {
            Name="Hamza",
            LastName="Gorcevic",
            Phone="0628967329",
            Year=2,
        }; 
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void NextYear_Click(object sender, RoutedEventArgs e)
        {
            student.Year += (student.Year < 4) ? 1 : 0; 

        }
    }
}
