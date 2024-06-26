using junski2024.Classes;
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

namespace junski2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

      
       

          

            ColumnDefinition columnDefinition = new ColumnDefinition();
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();


            podloga.ColumnDefinitions.Add(columnDefinition);
            podloga.ColumnDefinitions.Add(columnDefinition1);
            podloga.ColumnDefinitions.Add(columnDefinition2);


            AktivnaLuka aktivnaLuka = new AktivnaLuka("Beograd", 24, 1000000);

            AktivnaLuka aktivnaLuka1 = new AktivnaLuka("Novi pazar", 50, 1000000);



            Grid.SetColumn(aktivnaLuka.LukaPodloga, 0);

            AktivanBrod aktivanBrod = new AktivanBrod("Brod Avala",aktivnaLuka, aktivnaLuka1,15, 300, 70000, 7000);

            Grid.SetColumn(aktivanBrod.BrodPodloga, 1);
            Grid.SetColumn(aktivnaLuka1.LukaPodloga, 2);

            podloga.Children.Add(aktivnaLuka1.LukaPodloga);

            podloga.Children.Add(aktivanBrod.BrodPodloga);

            podloga.Children.Add(aktivnaLuka.LukaPodloga);




        }
    }
}
