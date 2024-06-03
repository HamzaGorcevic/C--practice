using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Parking.View
{
    /// <summary>
    /// Interaction logic for pageVlasnici.xaml
    /// </summary>
    public partial class pageVlasnici : Page,INotifyPropertyChanged
    {

        private VLASNIK noviVlasnik;
        public VLASNIK NoviVlasnik
        { 
            get { return noviVlasnik; }
            set { noviVlasnik = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<VLASNIK> vlasnici;
        public ObservableCollection<VLASNIK> Vlasnici
        {
            get { return vlasnici; }
            set { vlasnici = value;
               }
            
        }

        private parking_serviceEntities1 context = new parking_serviceEntities1();



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void ucitavanjeVlasnika()
        {
            Vlasnici = new ObservableCollection<VLASNIK>();
            var vl = context.VLASNIKs.ToList();
           

            foreach (var v in vl)
            {
                Vlasnici.Add(v);
            }
        }
        public pageVlasnici()
        {

            NoviVlasnik = new VLASNIK();
            
            ucitavanjeVlasnika();
            InitializeComponent();

        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.VLASNIKs.Add(NoviVlasnik);
            context.SaveChanges();
            Vlasnici.Add(NoviVlasnik); // Dodavanje vlasnika u ObservableCollection.
            NoviVlasnik = new VLASNIK(); // Resetovanje forme za unos novog vlasnika.
            MessageBox.Show("Vlasnik uspesno dodat");


        }
    }
}
