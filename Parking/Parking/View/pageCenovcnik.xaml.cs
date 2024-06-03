using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Parking.View
{
    /// <summary>
    /// Interaction logic for pageCenovcnik.xaml
    /// </summary>
    public partial class pageCenovcnik : Page
    {

        parking_serviceEntities1 context = new parking_serviceEntities1();

        public CENOVNIK Cenovnik { get; set; }
        public pageCenovcnik()
        {

            Cenovnik = context.CENOVNIKs.FirstOrDefault();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = context.SaveChanges();

        }
    }
}
