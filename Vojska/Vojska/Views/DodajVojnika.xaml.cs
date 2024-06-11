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
using Vojska.Models;

namespace Vojska.Views
{
    /// <summary>
    /// Interaction logic for DodajVojnika.xaml
    /// </summary>
    public partial class DodajVojnika : UserControl
    {
        public Vod vod;
        public DodajVojnika(Vod vod)
        {
            this.vod = vod;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Vojnik noviVojnik = new Vojnik();

            noviVojnik.Ime = ime.Text;


            try
            {
                DateTime rodjenje = DateTime.Parse(datum.Text);
                noviVojnik.DatumRodjenja = rodjenje;
                noviVojnik.Cin = (CinEnum)cbCin.SelectedIndex;

                vod.listVojnika.Add(noviVojnik);

                MessageBox.Show(vod.listVojnika[0].Ime);
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


            

        }
    }
}
