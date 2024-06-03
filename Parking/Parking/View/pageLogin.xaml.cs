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

namespace Parking.View
{
    /// <summary>
    /// Interaction logic for pageLogin.xaml
    /// </summary>
    public partial class pageLogin : Window
    {
        public pageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (true) //proverimo u bazi da li su korisnicko ime i lozinka ispravi
            {
                MainWindow main = new MainWindow();
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("Netacni podaci");
            }
        }
    }
}
