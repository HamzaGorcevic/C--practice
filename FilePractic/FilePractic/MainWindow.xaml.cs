using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilePractic
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

        private void Snimi()
        {
            // pokupi sve redove iz list box-a i da ih redom upisuje u datokeu 'podaci.txt'
            try
            {
                FileStream fs = new FileStream("podaci.txt", FileMode.Create, FileAccess.Write);
                // ovaj ce da pise
                StreamWriter sw = new StreamWriter(fs);
                foreach (var item in lbStavke.Items)
                {
                    sw.WriteLine(item.ToString());
                }
                sw.Close();
                MessageBox.Show("Da li ste sigurni da zelite izbrisati podatke");
                
                lbStavke.Items.Clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ucitaj()
        {
            try
            {
                FileStream fs = new FileStream("podaci.txt",FileMode.Open,FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                lbStavke.Items.Clear();
                while(!sr.EndOfStream)
                {
                    var item = sr.ReadLine();
                    lbStavke.Items.Add(item);
                }
                sr.Close();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dodajStavku()
        {
            var text = txtSadrzaj.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Niste uneli text");
                return;
            }
            // proverava da li stavka vec postoji u lixtbox-u
            if (lbStavke.Items.Contains(text))
            {
                MessageBox.Show("Stavka vec postoji u listbox-u");
                return;
            }
            lbStavke.Items.Add(text);
            txtSadrzaj.Text = string.Empty;
            txtSadrzaj.Focus();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            dodajStavku();
            

        }

        private void btnUcitaj_Click(object sender, RoutedEventArgs e)
        {
            if(lbStavke.Items.Count == 0 && MessageBox.Show(@"U list boxu vec postoje neke stavke da li ste sigurni da zelite da ih obrisete","Potvrda",MessageBoxButton.YesNo)==MessageBoxResult.No)
            {
                MessageBox.Show("Prazno !");
                return;

            }
            Ucitaj();

        }

        private void btnSnimi_Click(object sender, RoutedEventArgs e)
        {
            Snimi();

        }

        private void btnDodaj_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
            if(e.Key== Key.Enter)
            {
                dodajStavku();
            }
        }
    }
}