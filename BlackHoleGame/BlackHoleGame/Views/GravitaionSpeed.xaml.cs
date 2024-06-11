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

namespace BlackHoleGame.Views
{
    /// <summary>
    /// Interaction logic for GravitaionSpeed.xaml
    /// </summary>
    public partial class GravitaionSpeed : Window
    {

        private int gravity;
        public GravitaionSpeed()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(tbGravity.Text, out gravity))
            {
                MainWindow window = new MainWindow();
                window.Gravity = gravity;
                window.ShowDialog();
                this.Close();
            }
            else
            {
                tbGravity.Focus();
                MessageBox.Show("Try again");
            }



        }
    }
}
