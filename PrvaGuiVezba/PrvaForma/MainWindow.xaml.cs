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

namespace PrvaForma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string Name{get;set;}
        public string Sifra{get;set;}
        public MainWindow()
        {
            InitializeComponent();
            PodesiProzor();


        }

        public void PodesiProzor()
        {
            TextBox ime = new TextBox();   
            TextBox sifra = new TextBox();
            ime.Width = 150;
            ime.TextChanged += Ime_TextChanged;
            sifra.TextChanged += Sifra_TextChanged; 
            ime.Height = 30;
            ime.FontSize = 20;
            ime.Background = Brushes.AliceBlue;
            Canvas.SetTop(ime, 10);
            Canvas.SetLeft(ime, (this.Width - ime.Width) / 2);
            this.forma.Children.Add(ime);
            sifra.Width = 150;
            sifra.Height = 30;
            sifra.FontSize = 20;
            sifra.Background = Brushes.AliceBlue;
            Canvas.SetTop(sifra, 70);
            Canvas.SetLeft(sifra, (this.Width - sifra.Width) / 2);
            this.forma.Children.Add(sifra);
            Button dugme = new Button();
            dugme.Click += Dugme_Click;
            dugme.Content = "prijavi se";
            dugme.Width = 150;
            dugme.Height = 30;
            dugme.Name = "dugme";
                
            Canvas.SetTop(dugme, 120);
            Canvas.SetLeft(dugme, (this.Width - dugme.Width) / 2);
            this.forma.Children.Add(dugme);

        }

        

        private void Ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox imeInput  = sender as TextBox;
            Name = imeInput.Text;
        }

        private void Sifra_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox sifraInput = sender as TextBox;
            Sifra = sifraInput.Text;
        }

        private void Dugme_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(Name + Sifra);
        }
    }


}
