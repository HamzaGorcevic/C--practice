using BaraIspit.Models;
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
using System.Windows.Threading;

namespace BaraIspit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      

        private Povrs povrs;
        private Oblak oblak;

        public MainWindow()
        {
            InitializeComponent();


            povrs = new Povrs(300, 500);
            oblak = new Oblak(100, 20,100);
            oblak.OnKapaPala += povrs.RegisterKap;
            oblak.Zapocni();


      





                container.Children.Add(oblak.povrsina);
            container.Children.Add(povrs.Povrsnia);


            


        }

        private void Container_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("DAS");
          
        }
    }
}
