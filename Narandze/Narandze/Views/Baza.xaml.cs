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

namespace Narandze
{
    /// <summary>
    /// Interaction logic for Baza.xaml
    /// </summary>
    public partial class Baza : UserControl
    {

        public class Prosierana
        {
            private DateTime created;

            public DateTime CreatedAt
            {
                get { return created; }
                set { created = value;
                    getAllValeus();
                }
            }

            private int rows;

            public int Rows
            {
                get { return rows; }
                set { rows = value; }
            }

            private int columns;

            public int Columns
            {
                get { return columns; }
                set { columns = value; }
            }

            private int healthy;

            public int Healthy
            {
                get { return healthy; }
                set { healthy = value; }
            }

            private int ruined;

            public int Ruined
            {
                get { return ruined; }
                set { ruined = value; }
            }
            private int colleration;

            public int Colleration
            {
                get { return colleration; }
                set { colleration = value; }
            }

            public void Narandze()
            {
                getAllValeus();
               
            }

            void getAllValeus()
            {
                Ruined = (columns * Rows) - Healthy;
                colleration = Ruined / Healthy;
            }



        }
        narandzeEntities context = new narandzeEntities();




        public Baza()
        {
            Prosierana novaNarandza = new Prosierana();
            Narandze narandzaBaza =  context.Narandzes.FirstOrDefault();
            novaNarandza.Healthy = (int)narandzaBaza.Healthy;
            novaNarandza.Rows = (int)narandzaBaza.Rows;
            novaNarandza.Columns = (int)narandzaBaza.Columns;
            novaNarandza.CreatedAt = (DateTime)narandzaBaza.CreateadAt;

            List <Prosierana> lista = new List <Prosierana>();

            lista.Add (novaNarandza);
            gridBaza.ItemsSource = lista;
            DataContext = this;




            InitializeComponent();
        }
    }
}
