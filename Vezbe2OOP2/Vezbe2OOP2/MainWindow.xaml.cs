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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vezbe2OOP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          

            /*            cbSelectColor.DataContextChanged += CbSelectColor_DataContextChanged;
            */
        }
        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            dogText.Text = "PRozor se pokrenuo" + Environment.NewLine;
            cbSelectColor.Items.Add("Black");
            cbSelectColor.Items.Add("Red");

            cbSelectColor.Items.Add("White");

        }

        /* private void CbSelectColor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
         {

             switch (cbSelectColor.SelectedValue)
             {
                 case "Black":

             }
         }*/

        public void Windows_Close(object sender, RoutedEventArgs e)
        {


        }
        public void Windwos_MouseMove(object sender, MouseEventArgs e)
        {
            dogText.Text += $"Pomerio se kursor na poziviji {e.GetPosition(this)}";
        }
    }
}
