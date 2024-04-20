using System;
using System.Collections.Generic;
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

namespace Zadatak2
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
        private string putanjaZaList = "PodaciZaLB.txt";
        private string putanjaZaCombo = "PodaciZaCombo.txt";
        #region ComboBox
        private void txtZaCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DodajStavku();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajStavku();

        }
        private void DodajStavku()
        {
            var text = txtZaCombo.Text;
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (cbSadrzaj.Items.Contains(text))
            {
                return;
            }
            cbSadrzaj.Items.Add(text);
            txtZaCombo.Text = string.Empty;
            txtZaCombo.Focus();
            brCombo.Text = cbSadrzaj.Items.Count.ToString();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream(putanjaZaCombo, FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(fs);

                foreach (var stavka in cbSadrzaj.Items)
                {
                    sw.WriteLine(stavka.ToString());
                }
                cbSadrzaj.Items.Clear();
                brCombo.Text = cbSadrzaj.Items.Count.ToString();
                sw.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream(putanjaZaCombo, FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs);

                cbSadrzaj.Items.Clear();
                while (!sr.EndOfStream)
                {
                    cbSadrzaj.Items.Add(sr.ReadLine());

                }
                brCombo.Text = cbSadrzaj.Items.Count.ToString();
                sr.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void cbSadrzaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = cbSadrzaj.SelectedItem as string;
                if (selected != null)
                {
                    izabranoCombo.Text = selected;
                }

            }
            catch
            {
                MessageBox.Show("niste selektrovali ispravan element u combox");

            }

        }

        #endregion


        #region ListBox

      
        private void txtZaList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DodajStavkuUListu();
            }

        }

        private void ButtonZaList_Click(object sender, RoutedEventArgs e)
        {
            DodajStavkuUListu();

        }
        private void DodajStavkuUListu()
        {
            var text = txtIzabranoLB.Text;
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (lbSadrzaj.Items.Contains(text))
            {
                return;
            }
            lbSadrzaj.Items.Add(text);
            txtZaCombo.Text = string.Empty;
            txtZaCombo.Focus();
            txtBrRedovaLB.Text = lbSadrzaj.Items.Count.ToString();


        }

        private void SnimiList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream(putanjaZaList, FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(fs);

                foreach (var stavka in lbSadrzaj.Items)
                {
                    sw.WriteLine(stavka.ToString());
                }
                sw.Close();
                lbSadrzaj.Items.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UcitajList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fs = new FileStream(putanjaZaList, FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs);

                lbSadrzaj.Items.Clear();
                while (!sr.EndOfStream)
                {
                    lbSadrzaj.Items.Add(sr.ReadLine());

                }
                sr.Close();
                lbSadrzaj.Items.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void lbSadrzaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = lbSadrzaj.SelectedItem as string;
                if (selected != null)
                {
                    txtIzabranoLB.Text = selected;
                }

            }
            catch
            {
                MessageBox.Show("niste selektrovali ispravan element u listboxu");

            }

        }
        #endregion
    }
}
