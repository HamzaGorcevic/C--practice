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
using System.Windows.Shapes;

namespace Narandze
{
    /// <summary>
    /// Interaction logic for Unos.xaml
    /// </summary>
    public partial class Unos : Window
    {
        public int rowsValue;
        public int columnsValues;

        public delegate void loadData();
        public event loadData onloadData;
        public Unos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rowsValue= int.Parse(inputRows.Text);
            columnsValues= int.Parse(inputColumns.Text);
            onloadData.Invoke();
           
            this.Close();

        }
    }
}
