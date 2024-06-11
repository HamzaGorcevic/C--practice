

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ListaVojnika.xaml
    /// </summary>
    public partial class ListaVojnika : UserControl
    {
        public ObservableCollection<Vojnik> Vojnici { get; set; }

        public delegate void UnaprediVojnika();

        public event UnaprediVojnika unapredivojnika;

        public ListaVojnika(Vod vod)
        {

           
            Vojnici = vod.listVojnika;
            var nes =Vojnici.FirstOrDefault();
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Vojnici)
            {
                unapredivojnika += item.UnaprediMe;

                
            }
            unapredivojnika();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
               var vojniciSorted = new ObservableCollection<Vojnik>(Vojnici.OrderBy((vojnik)=>vojnik.DatumRodjenja));

            Vojnici.Clear();
            foreach (var item in vojniciSorted)
            {
                Vojnici.Add(item);

                
            }

        }

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            FilePath filePathModal = new FilePath();

            filePathModal.ShowDialog();

            if (filePathModal.DialogResult == true)
            {
                string path = FilePath.InputFilePath;

                string Buffer = "";
                foreach (var item in Vojnici)
                {
                    Buffer += item.Ime;


                }
                try
                {
                    File.WriteAllText(path, Buffer);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (File.Exists(path))
                {
                    filePathModal.Close();
                    MessageBox.Show("Uspesno ste uneli");
                }
                else
                {
                    MessageBox.Show("doslo je do gresek prilikom kreiranja fajla");
                }


            }



       





        }
    }



}
