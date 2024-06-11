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
using Vojska.Models;
using Vojska.Views;

namespace Vojska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Vod vod;
        public MainWindow()
        {
            vod = new Vod();

            this.Closing += MainWindow_Closing;
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("Da li ste sigurni da zelite izbrisati poruku?","Potvrdite",MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {

                if (File.Exists(FilePath.InputFilePath))
                {
                File.Delete(FilePath.InputFilePath);

                }
                else
                {
                    MessageBox.Show("fajl ne postoji");
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajVojnika dodajVojnika = new DodajVojnika(vod);
            contentArea.Content = dodajVojnika;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListaVojnika listaVojnika = new ListaVojnika(vod);

            contentArea.Content = listaVojnika;
        }
    }
}
