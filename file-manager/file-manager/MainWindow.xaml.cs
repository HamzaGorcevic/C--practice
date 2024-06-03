using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace file_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void PretragaPutanje()
        {
            try
            {
                string putanja = txtPutanja.Text;
                var di = new DirectoryInfo(putanja);
                lbFolder.Items.Clear();

                foreach (var folder in di.GetDirectories())
                {
                    lbFolder.Items.Add(folder.FullName);

                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Pretrazi_Click(object sender, RoutedEventArgs e)
        {
            PretragaPutanje(); 

        }

        private void lbFolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var naziv = lbFolder.SelectedItem as string;
                string putanja = naziv;
                var di = new DirectoryInfo(putanja);
                lbFajlovi.Items.Clear();
                foreach(var fajl in di.GetFiles())
                {
                    lbFajlovi.Items.Add(fajl.FullName);
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbFolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var putanja = lbFolder.SelectedItem.ToString() as string;

            txtPutanja.Text = putanja;
            PretragaPutanje();
        }


        // mogucnost kopiranja fajlova, birsanja uz potvrdu messagebox-a
        private void lbFajlovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Process.Start(lbFajlovi.SelectedItem.ToString());

            }catch
            {
                MessageBox.Show("greska u otvaranju fajla");
            }
        }
    }
}
